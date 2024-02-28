import { Injectable } from '@angular/core';
import { SystemConfigModel } from '../models/system-config.model';

@Injectable()
export class FixedService {
  public userProfile: any = {};
  public activeLang: any = {};
  public appLanguages: any = [];
  public deleteSwalConfig: any = {};
  public allowAnonymous = ['token', 'Token/Refresh'];
  public sysConfig = new SystemConfigModel();
  public tokenRequestSent = false;
  public requestWithoutLoader = [];
  public subheader;

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
