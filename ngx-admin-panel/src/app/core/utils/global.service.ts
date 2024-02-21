import { Injectable } from '@angular/core';
import { FixedService } from './fixed.service';
import { StorageMap } from '@ngx-pwa/local-storage';
import { CookieEnum } from '../enums/cookie.enum';
import { TranslateService } from '@ngx-translate/core';

@Injectable({ providedIn: 'root' })
export class GlobalService {
  constructor(
    public fixed: FixedService,
    private storage: StorageMap,
    private translate: TranslateService
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

  themeSettings(applang: any){

  }
}
