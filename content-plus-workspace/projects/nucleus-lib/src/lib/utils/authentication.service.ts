import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PermanentService } from './permanent.service';
import { Observable } from 'rxjs';
import { CookiesEnum } from '../enums/cookies.enum';
import { CookieService } from 'ngx-cookie-service';

@Injectable()
export class AuthenticationService {
  constructor(
    private http: HttpClient,
    private cookieSer: CookieService,
    private permanent: PermanentService
  ) {}

  obtainAccessToken(loginData: any): Observable<any> {
    return this.http.post(this.permanent.sysConfig.serverUrl + 'Token', loginData);
  }

  saveToken(data: any) {
    this.cookieSer.set(CookiesEnum.Token, data.token, new Date(data.expiration), '/');
    this.cookieSer.set(CookiesEnum.RefreshToken, data.refresh.token, new Date(data.refresh.expiresUtc), '/');

    const excludedKeys = ['token', 'refresh', 'expiration'];

    let cookieData = JSON.parse(this.cookieSer.get(CookiesEnum.StoredKeys) || '{"keys": [], "expiresUtc": null}');
    let storedKeys: string[] = cookieData.keys || [];

    Object.keys(data).forEach(key => {
      if (!excludedKeys.includes(key)) {
        localStorage.setItem(key, JSON.stringify(data[key]));
        if (!storedKeys.includes(key)) {
          storedKeys.push(key);
        }
      }
    });

    const updatedCookieData = {
      keys: storedKeys,
      expiresUtc: cookieData.expiresUtc || new Date(data.refresh.expiresUtc).toISOString(),
    };
    this.cookieSer.set(CookiesEnum.StoredKeys, JSON.stringify(updatedCookieData), new Date(data.refresh.expiresUtc), '/');
  }

  logout() {
    if (window.location.pathname.indexOf('login') < 0) {
      this.cookieSer.deleteAll('/');
      window.location.href = '/login';
    }
  }

  obtainRefreshToken() {
    return this.http.post(this.permanent.sysConfig.serverUrl + 'Token/Refresh', {
      refreshToken: this.cookieSer.get(CookiesEnum.RefreshToken),
    });
  }

  isAuthenticated() {
    return !this.cookieSer.check(CookiesEnum.RefreshToken) && !this.cookieSer.check(CookiesEnum.Token) && !this.cookieSer.check(CookiesEnum.StoredKeys)
      ? false
      : true;
  }
}
