import { Injectable } from '@angular/core';

@Injectable()
export class FixedService {
  public activeLang: any = {};
  public appLanguages: any = [];
  public deleteSwalConfig: any = {};

  constructor() {
    this.initialAppLang();
  }

  initialAppLang() {
    this.appLanguages = [
      {
        languageId: 1,
        isRTL: true,
        code: 'ar',
        name: 'عربي',
        dir: 'rtl',
        icon: 'flag-icon-sa',
        title: 'لوحة التحكم - إدارة المحتوي',
        dateFormat: 'ar-SA',
      },
      {
        languageId: 2,
        isRTL: false,
        code: 'en',
        name: 'English',
        dir: 'ltr',
        icon: 'flag-icon-uk',
        title: 'Admin Panel - CMS',
        dateFormat: 'en-US',
      },
    ];
  }
}
