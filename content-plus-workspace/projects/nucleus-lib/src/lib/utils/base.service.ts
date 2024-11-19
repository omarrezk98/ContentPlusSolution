import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UniversalService } from './universal.service';
import { PermanentService } from './permanent.service';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { ToastrEnum } from '../enums/toastr.enum';

@Injectable()
export class BaseService {
  list: any = [];
  requestSent = false;
  id: string;
  url: string;
  listPage: string;
  operationPage: string;

  constructor(
    public http: HttpClient,
    public universal: UniversalService,
    public permanent: PermanentService,
    public router: Router
  ) {}

  private get baseUrl(): string {
    return this.permanent.sysConfig.serverUrl + this.url;
  }

  getById(id): Observable<any> {
    if (id == null) id = '';
    return this.http.get(this.baseUrl + 'GetById/' + id);
  }

  operation(model): Observable<any> {
    return model[this.id] == null ? this.http.post(this.baseUrl + 'Insert', model) : this.http.put(this.baseUrl + 'Edit', model);
  }

  delete(id): Observable<any> {
    return this.http.delete(this.baseUrl + 'Delete/' + id);
  }

  search(model): Observable<any> {
    return this.http.post(this.baseUrl + 'Search', model);
  }

  upload(model): Observable<any> {
    return this.http.post(this.baseUrl + 'Upload', model);
  }

  searchByTerm(term, includeIds?, otherParams?): Observable<any> {
    term = term == null ? '' : term;
    includeIds = includeIds == null ? '' : includeIds;
    otherParams = otherParams == null ? '' : otherParams;
    return this.http.get(this.baseUrl + 'SearchByTerm?term=' + term + '&includeIds=' + includeIds + otherParams);
  }

  getAll() {
    if (!this.requestSent) {
      this.requestSent = true;
      this.list = undefined;
      this.http.get(this.baseUrl + 'GetAll').subscribe({
        next: (response: any) => {
          this.list = response;
          this.requestSent = false;
        },
        error: err => {
          this.universal.toastrMessage(ToastrEnum.Failed, null, null, err);
          this.requestSent = false;
        },
      });
    }
  }

  export(url, model) {
    if (!this.requestSent) {
      this.requestSent = true;
      this.universal.loading(true);
      this.http
        .post(url, model, {
          reportProgress: true,
          observe: 'events',
          responseType: 'blob',
        })
        .subscribe({
          next: event => {
            if (event instanceof HttpResponse) {
              this.downloadFile(url, event);
              this.universal.loading(false);
              this.requestSent = false;
            }
          },
          error: err => {
            this.universal.loading(false);
            this.universal.toastrMessage(ToastrEnum.Failed);
          },
        });
    }
  }

  getPatientFile(patientFileId) {
    if (!this.requestSent) {
      this.requestSent = true;
      this.universal.loading(true);
      this.http
        .get('PatientFile/GetById/' + patientFileId, {
          reportProgress: true,
          observe: 'events',
          responseType: 'blob',
        })
        .subscribe({
          next: event => {
            if (event instanceof HttpResponse) {
              this.downloadFile(patientFileId, event);
              this.universal.loading(false);
              this.requestSent = false;
            }
          },
          error: err => {
            this.universal.loading(false);
            this.universal.toastrMessage(ToastrEnum.Failed);
            this.requestSent = false;
          },
        });
    }
  }

  downloadFile(url, event) {
    let data = event as HttpResponse<Blob>;
    const downloadedFile = new Blob([data.body as BlobPart], {
      type: data.body?.type,
    });
    if (downloadedFile.type != '') {
      const a = document.createElement('a');
      a.setAttribute('style', 'display:none;');
      document.body.appendChild(a);
      a.download = url + new Date().toString() + this.universal.generateCode(10);
      a.href = URL.createObjectURL(downloadedFile);
      a.target = '_blank';
      a.click();
      document.body.removeChild(a);
    }
  }

  print(id) {
    if (!this.requestSent) {
      this.requestSent = true;
      this.universal.loading(true);
      this.http
        .get(this.baseUrl + 'ExportPdf/' + id, {
          reportProgress: true,
          observe: 'events',
          responseType: 'blob',
        })
        .subscribe({
          next: (response: any) => {
            if (response instanceof HttpResponse) {
              this.universal.loading(false);
              this.requestSent = false;
              this.printFile(response);
            }
          },
          error: err => {
            this.universal.toastrMessage(ToastrEnum.Failed, null, null, err);
            this.requestSent = false;
            this.universal.loading(false);
          },
        });
    }
  }

  printFile(event) {
    let data = event as HttpResponse<Blob>;
    const downloadedFile = new Blob([data.body as BlobPart], {
      type: data.body?.type,
    });
    const objectUrl = URL.createObjectURL(downloadedFile);
    let printWindow: any = window.open(objectUrl, '_blank');
    printWindow.onload = () => {
      printWindow.print();
      printWindow.onafterprint = () => {
        URL.revokeObjectURL(objectUrl);
        printWindow.document.close();
      };
    };
  }

  reportLang() {
    let headersToSend = new HttpHeaders();
    headersToSend = headersToSend.set('responseType', 'text').set('Lang', this.permanent.activeLang.code);
    return headersToSend;
  }

  swalDelete(id, runGetAll?: Boolean) {
    Swal.fire(this.permanent.deleteSwalConfig).then(result => {
      if (result.value) {
        this.universal.loading(true);
        this.http.delete(this.baseUrl + 'Delete/' + id).subscribe({
          next: (response: any) => {
            this.universal.toastrMessage(ToastrEnum.Success);
            if (this.listPage != null) this.router.navigate([this.listPage]);
            if (runGetAll) this.getAll();
            this.universal.loading(false);
          },
          error: err => {
            this.universal.loading(false);
            this.universal.toastrMessage(ToastrEnum.Failed, null, null, err);
          },
        });
      }
    });
  }

  reload() {
    this.requestSent = false;
    this.list = [];
    this.getAll();
  }
}
