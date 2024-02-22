import { Injectable } from '@angular/core';
import { FixedService } from './fixed.service';
import { StorageMap } from '@ngx-pwa/local-storage';
import { CookieEnum } from '../enums/cookie.enum';
import { TranslateService } from '@ngx-translate/core';
import { Title } from '@angular/platform-browser';
import { BehaviorSubject, forkJoin } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class GlobalService {
  appLangChanged: BehaviorSubject<any> = new BehaviorSubject<any>(null);

  constructor(
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
    this.storage
      .set(CookieEnum.AppLang, this.fixed.activeLang)
      .subscribe(() => {});
    this.setLang(this.fixed.activeLang.code);
    this.appLangChanged.next(this.fixed.activeLang);
    this.generateSwalConfig();
  }

  generateSwalConfig() {
    forkJoin([
      this.translate.get('Common.DeleteConfirmMessage'),
      this.translate.get('Common.Confirm'),
      this.translate.get('Common.Cancel'),
    ]).subscribe((results) => {
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
    });
  }
}
