import { Injectable } from '@angular/core';
import { PermanentService } from './permanent.service';
import { Title } from '@angular/platform-browser';
import { BehaviorSubject, forkJoin, map, Observable } from 'rxjs';
import { ToastrEnum } from '../enums/toastr.enum';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { CookiesEnum } from '../enums/cookies.enum';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
// import { PartTypeEnum } from '../enums/part-type.enum';
// import { PermissionTypeEnum } from '../enums/permission-type.enum';

@Injectable({
  providedIn: 'root'
})
export class UniversalService {
  toastrOptions: any;
  appLangChanged: BehaviorSubject<any> = new BehaviorSubject<any>(null);
  subheaderChanged: BehaviorSubject<any> = new BehaviorSubject<any>(null);

  constructor(
    private toastrSer: ToastrService,
    private translate: TranslateService,
    public permanent: PermanentService,
    private titleSer: Title,
    private router: Router
  ) {
    let lang: any = localStorage.getItem(CookiesEnum.appLang);
    this.permanent.activeLang = lang == null ? this.permanent.appLanguages[1] : JSON.parse(lang);
    this.themeSettings(this.permanent.activeLang);
    this.setLang(this.permanent.activeLang?.code);
  }

  //#region language settings
  private setLang(lang: any) {
    this.translate.addLangs(['en', 'ar']);
    this.translate.setDefaultLang('en');
    this.translate.use(lang);
  }

  themeSettings(appLang: any) {
    this.permanent.activeLang = appLang;
    const html = document.getElementsByTagName('html')[0] as HTMLHtmlElement;
    html.setAttribute('lang', this.permanent.activeLang?.code);
    html.setAttribute('dir', this.permanent.activeLang?.dir);
    html.setAttribute('direction', this.permanent.activeLang?.dir);
    html.setAttribute('style', 'direction: ' + this.permanent.activeLang?.dir);

    const body = document.getElementsByTagName('body')[0] as HTMLBodyElement;
    body.setAttribute('dir', appLang.dir);
    body.dir = appLang.dir;
    if (appLang.dir == 'rtl') {
      body.classList.add('rtl');
    } else {
      body.classList.remove('rtl');
    }
    this.titleSer.setTitle(appLang.title);
    localStorage.setItem(CookiesEnum.appLang, JSON.stringify(appLang));
    this.setLang(this.permanent.activeLang?.code);
    this.appLangChanged.next(this.permanent.activeLang);
    this.generateSwalConfig();
  }

  private generateSwalConfig() {
    forkJoin([this.translate.get('Common.DeleteConfirmMessage'), this.translate.get('Common.Confirm'), this.translate.get('Common.Cancel')]).subscribe(
      results => {
        this.permanent.deleteSwalConfig = {
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
  //#endregion

  //#region user interface actions like toaster, loading, language
  toastrMessage(type: ToastrEnum, titleKey?: string | null, messageKey?: string | null, err?: any, position?: string): void {
    if (err?.status === 403) return;
    this.setToastrOptions(position);
    this.getToastrConfig(type, titleKey, messageKey).subscribe((config: any) => {
      this.toastrSer.show(config.message, config.title, this.toastrOptions, config.severity);
    });
  }

  private setToastrOptions(position?: string): void {
    let lang: any = localStorage.getItem(CookiesEnum.appLang);
    const activeLang: any = JSON.parse(lang);
    this.toastrOptions = {
      positionClass: position || (activeLang?.isRTL ? 'toast-top-left' : 'toast-top-right'),
      progressBar: true,
      progressAnimation: 'increasing',
      closeButton: true,
    };
  }

  private getToastrConfig(type: ToastrEnum, customTitleKey?: string | null, customMessageKey?: string | null): Observable<any> {
    const config: { [key in ToastrEnum]: { titleKey: string; messageKey: string; severity: string } } = {
      [ToastrEnum.Success]: { titleKey: 'Message.Successful', messageKey: 'Message.SuccessfulText', severity: 'toast-success' },
      [ToastrEnum.InProgress]: { titleKey: 'Message.InProgress', messageKey: 'Message.InProgressText', severity: 'toast-info' },
      [ToastrEnum.ValidationError]: { titleKey: 'Message.Warning', messageKey: 'Message.WarningText', severity: 'toast-warning' },
      [ToastrEnum.Failed]: { titleKey: 'Message.Unsuccessful', messageKey: 'Message.UnsuccessfulText', severity: 'toast-error' },
    };

    const { titleKey, messageKey, severity } = config[type];

    return forkJoin([this.translate.get(customTitleKey || titleKey), this.translate.get(customMessageKey || messageKey)]).pipe(
      map(([translatedTitle, translatedMessage]) => ({
        title: translatedTitle,
        message: translatedMessage,
        severity,
      }))
    );
  }

  loading(type?: boolean) {
    const body = document.getElementsByTagName('body')[0] as HTMLBodyElement;
    const existingLoader = document.querySelector('.page-loader') as HTMLElement;

    if (type === true) {
      body.classList.add('page-loading');

      if (!existingLoader) {
        const loaderDiv = document.createElement('div');
        loaderDiv.className = 'page-loader';
        loaderDiv.style.cssText = 'background-color: rgb(255 255 255 / 60%);';
        loaderDiv.innerHTML = `
        <img alt="Logo" id="loader-logo" src="data:image/png;base64,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" />
        <span class="spinner-border text-primary" role="status"></span>
      `;
        body.appendChild(loaderDiv);
      }
    } else {
      body.classList.remove('page-loading');

      if (existingLoader) {
        existingLoader.remove();
      }
    }
  }

  closePage(url?) {
    forkJoin([this.translate.get('Message.Warning'), this.translate.get('Message.OperationError')]).subscribe(results => {
      Swal.fire({
        icon: 'error',
        title: results[0],
        html: `<span class='red-custom text-bold'>` + results[1] + `</span>`,
        showCloseButton: false,
        showCancelButton: false,
        showConfirmButton: false,
        allowOutsideClick: false,
      });
    });
    setTimeout(() => {
      Swal.close();
      if (url != null) {
        this.router.navigate([url]);
      }
    }, 5000);
  }
  //#endregion

  //#region reactive form tools
  removeSpacesinFormControl(f: any) {
    const keys = Object.keys(f.controls);
    keys.forEach(key => {
      const value = f.controls[key].value;
      if (typeof value == 'string' && value != null) {
        f.controls[key].setValue(f.controls[key].value.trim());
      }
      if (/^ *$/.test(f.controls[key].value)) {
        f.controls[key].setValue(null);
      }
    });
  }
  //#endregion

  //#region values shared in url
  saveParamInUrl(pageUrl, paramsUrl, obj) {
    const key = Object.keys(obj)[0];
    let value = obj[key];
    if (Array.isArray(obj[key]) && obj[key].length == 0) {
      value = null;
      obj[key] = null;
    }
    if (paramsUrl[key]) delete paramsUrl[key];
    if (value !== null && value !== '' && value !== 'NaN-NaN-NaN' && value !== undefined) paramsUrl = Object.assign(obj, paramsUrl);
    this.router.navigate([pageUrl, paramsUrl]);
    return paramsUrl;
  }

  readValuesFromURL(f, params) {
    const keys = Object.keys(params);
    keys.forEach(ele => {
      let val = params[ele];
      if (
        ele.indexOf('Id') > 0 ||
        ele.indexOf('code') > 0 ||
        ele == 'page' ||
        ele == 'recordPerPage' ||
        ele == 'dateRange' ||
        ele == 'orderBy' ||
        ele == 'dataView'
      ) {
        val = Number(val);
      } else if (ele.indexOf('Date') > 0 || ele == 'date') {
        val = new Date(val);
      } else if (ele.indexOf('List') > 0) {
        val = JSON.parse('[' + val + ']');
      } else if (val == 'false' || val == 'true') {
        val = val == 'true';
      }
      f[ele]?.setValue(val);
      if (ele == 'dateRange' && val == -1) {
        f['operationDateFrom']?.setValue(null);
        f['operationDateTo']?.setValue(null);
      }
    });
    return Object.assign({}, params);
  }
  //#endregion

  // privilegePage(PartType: PartTypeEnum, permissionType: PermissionTypeEnum) {
  //   if (!PartType || !permissionType) return;
  //   const userPermissionsString = localStorage.getItem('userPermissions');
  //   if (!userPermissionsString) {
  //     this.router.navigate(['/error/404']);
  //     return false;
  //   }
  //   const userPermissions = JSON.parse(userPermissionsString);
  //   const sub = userPermissions.find(
  //     (e: { partTypeId: PartTypeEnum; permissionTypeId: PermissionTypeEnum }) => e.partTypeId == PartType && e.permissionTypeId == permissionType
  //   );
  //   if (sub == undefined) {
  //     this.router.navigate(['/error/404']);
  //     return false;
  //   }
  //   return true;
  // }

  generateCode(length) {
    var result = '';
    var characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    var charactersLength = characters.length;
    for (var i = 0; i < length; i++) {
      result += characters.charAt(Math.floor(Math.random() * charactersLength));
    }
    return result;
  }

  customSearchFn(term: string, item?: any) {
    const customSearchFnKeys = ['nameEn', 'nameAr', 'fullName', 'name', 'valueAr', 'valueEn'];
    for (let i = 0; i < customSearchFnKeys.length; i++) {
      if (item[customSearchFnKeys[i]] != null && item[customSearchFnKeys[i]].includes(term)) {
        return item;
      } else if (item[customSearchFnKeys[i]] != null && item[customSearchFnKeys[i]].toLowerCase().includes(term.toLowerCase())) {
        return item;
      }
    }
    return null;
  }

  convertEnumToArray(enuum: any) {
    return Object.keys(enuum)
      .filter(key => !isNaN(Number(enuum[key])))
      .map(key => ({ id: enuum[key], name: key }));
  }
}
