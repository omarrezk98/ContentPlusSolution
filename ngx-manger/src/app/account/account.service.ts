import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { StorageMap } from '@ngx-pwa/local-storage';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';
import { CookieEnum } from 'src/app/core/enums/cookie.enum';
import { FixedService } from 'src/app/core/utils/fixed.service';

@Injectable({ providedIn: 'root' })
export class AccountService {
  constructor(
    public fixed: FixedService,
    private storageMap: StorageMap,
    private http: HttpClient,
    private cookieSer: CookieService,
    private router: Router
  ) {}
  obtainAccessToken(loginData): Observable<any> {
    return this.http.post('token', loginData);
  }

  saveToken(data) {
    this.cookieSer.deleteAll();
    this.cookieSer.set(CookieEnum.AdminToken, data.token, new Date(data.expiration), '/');
    this.cookieSer.set(CookieEnum.AdminRefresh, data.refresh.token, new Date(data.refresh.expiresUtc), '/');
    this.storageMap.set(CookieEnum.AdminProfile, data.profile).subscribe(() => {});
  }

  refreshToken(data) {
    this.cookieSer.deleteAll();
    this.cookieSer.set(CookieEnum.AdminToken, data.token, new Date(data.expiration), '/');
    this.cookieSer.set(CookieEnum.AdminRefresh, data.refresh.token, new Date(data.refresh.expiresUtc), '/');
  }

  logout() {
    if (window.location.pathname.indexOf('login') < 0) {
      this.storageMap.clear().subscribe(() => {
        this.http.post('Token/Logout', { refreshToken: this.cookieSer.get(CookieEnum.AdminRefresh) }).subscribe(() => {});
        this.fixed = new FixedService();
        this.cookieSer.deleteAll('/');
        window.location.href =
          window.location.pathname.indexOf('login') > 0 && window.location.pathname.indexOf('returnUrl') > 0
            ? this.router.url
            : '/login?returnUrl=' + this.router.url;
      });
    }
  }

  obtainRefreshToken() {
    return this.http.post('Token/Refresh', {
      refreshToken: this.cookieSer.get(CookieEnum.AdminRefresh),
    });
  }

  isAuthenticated() {
    return !this.cookieSer.check(CookieEnum.AdminToken) && !this.cookieSer.check(CookieEnum.AdminRefresh) ? false : true;
  }

  changePassword(model): Observable<any> {
    return this.http.post('Account/ChangePassword/', model);
  }
}
