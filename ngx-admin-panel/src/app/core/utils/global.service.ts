import { Injectable } from '@angular/core';
import { FixedService } from './fixed.service';
import { StorageMap } from '@ngx-pwa/local-storage';
import { CookieEnum } from '../enums/cookie.enum';
import { TranslateService } from '@ngx-translate/core';
import { Title } from '@angular/platform-browser';
import { BehaviorSubject, forkJoin } from 'rxjs';
import { ResponseEnum } from '../enums/response.enum';
import { ToastrService } from 'ngx-toastr';

@Injectable({ providedIn: 'root' })
export class GlobalService {
  appLangChanged: BehaviorSubject<any> = new BehaviorSubject<any>(null);
  mainDataLoaded: BehaviorSubject<any> = new BehaviorSubject<any>(null);
  toastrOptions: any;

  constructor(
    private toastrSer: ToastrService,
    public fixed: FixedService,
    private storage: StorageMap,
    private translate: TranslateService,
    private titleSer: Title
  ) {
    this.storage.get(CookieEnum.AppLang).subscribe((data: any) => {
      this.fixed.activeLang = data == null ? this.fixed.appLanguages[1] : data;
      this.themeSettings(this.fixed.activeLang);
      this.setLang(this.fixed.activeLang.code);
    });
  }

  setLang(lang: any) {
    this.translate.addLangs(['en', 'ar']);
    this.translate.setDefaultLang('en');
    this.translate.use(lang);
  }

  themeSettings(appLang: any) {
    this.fixed.activeLang = appLang;
    const html = document.getElementsByTagName('html')[0] as HTMLHtmlElement;
    html.setAttribute('lang', this.fixed.activeLang.code);
    html.setAttribute('dir', this.fixed.activeLang.dir);
    html.setAttribute('direction', this.fixed.activeLang.dir);
    html.setAttribute('style', 'direction: ' + this.fixed.activeLang.dir);

    const body = document.getElementsByTagName('body')[0] as HTMLBodyElement;
    body.setAttribute('dir', appLang.dir);
    body.dir = appLang.dir;
    if (appLang.dir == 'rtl') {
      body.classList.add('rtl');
    } else {
      body.classList.remove('rtl');
    }
    this.titleSer.setTitle(appLang.title);
    this.storage.set(CookieEnum.AppLang, this.fixed.activeLang).subscribe(() => {});
    this.setLang(this.fixed.activeLang.code);
    this.appLangChanged.next(this.fixed.activeLang);
    this.generateSwalConfig();
  }

  generateSwalConfig() {
    forkJoin([this.translate.get('Common.DeleteConfirmMessage'), this.translate.get('Common.Confirm'), this.translate.get('Common.Cancel')]).subscribe(
      results => {
        this.fixed.deleteSwalConfig = {
          icon: 'error',
          title: results[0],
          confirmButtonText: results[1],
          cancelButtonText: results[2],
          confirmButtonColor: '#d33',
          focusCancel: true,
          focusConfirm: false,
          showCloseButton: false,
          showCancelButton: true,
          showConfirmButton: true,
        };
      }
    );
  }

  notificationMessage(type: ResponseEnum, title?: string, message?: string, err?: any, position?) {
    if (err != null && err.status === 403) return;
    this.toastrOptions = {
      positionClass: position == null ? (this.fixed.activeLang.isRTL ? 'toast-top-left' : 'toast-top-right') : position,
      progressBar: true,
      progressAnimation: 'increasing',
      closeButton: true,
    };
    let severity;
    if (type === ResponseEnum.Success) {
      forkJoin([this.translate.get('Message.Successful'), this.translate.get('Message.SuccessfulText')]).subscribe(results => {
        title = title ? title : results[0];
        message = message ? message : results[1];
        severity = 'toast-success';
        this.toastrSer.show(message, title, this.toastrOptions, severity);
      });
    } else if (type === ResponseEnum.InProgress) {
      forkJoin([this.translate.get('Message.InProgress'), this.translate.get('Message.InProgressText')]).subscribe(results => {
        title = title ? title : results[0];
        message = message ? message : results[1];
        severity = 'toast-info';
        this.toastrSer.show(message, title, this.toastrOptions, severity);
      });
    } else if (type === ResponseEnum.ValidationError) {
      forkJoin([this.translate.get('Message.Warning'), this.translate.get('Message.WarningText')]).subscribe(results => {
        title = title ? title : results[0];
        message = message ? message : results[1];
        severity = 'toast-warning';
        this.toastrSer.show(message, title, this.toastrOptions, severity);
      });
    } else if (type === ResponseEnum.Failed) {
      forkJoin([this.translate.get('Message.Unsuccessful'), this.translate.get('Message.UnsuccessfulText')]).subscribe(results => {
        title = title ? title : results[0];
        message = message ? message : results[1];
        severity = 'toast-error';
        this.toastrSer.show(message, title, this.toastrOptions, severity);
      });
    }
  }

  loading(type?: boolean, url?) {
    const check = url != null ? this.fixed.requestWithoutLoader.filter(s => s === url.split('?')[0])[0] : null;
    if (check != null) return;
    const body = document.getElementsByTagName('body')[0] as HTMLBodyElement;
    type === true ? body.classList.add('page-loading') : body.classList.remove('page-loading');
  }
}
