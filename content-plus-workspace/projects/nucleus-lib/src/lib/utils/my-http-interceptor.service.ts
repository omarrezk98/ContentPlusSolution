import { HttpErrorResponse, HttpEvent, HttpHandlerFn, HttpInterceptorFn, HttpRequest } from '@angular/common/http';
import { inject, Injector } from '@angular/core';
import { catchError, throwError, Observable, Subject } from 'rxjs';
import { PermanentService } from './permanent.service';
import { CookiesEnum } from '../enums/cookies.enum';
import { ToastrEnum } from '../enums/toastr.enum';
import { CookieService } from 'ngx-cookie-service';
import { AuthenticationService } from './authentication.service';
import { UniversalService } from './universal.service';
import { PendingRequest } from '../models/pending-request.model';
import { HttpClient } from '@angular/common/http';


let newToken: string;
let queue: PendingRequest[] = [];

export class MyHttpInterceptorService {
  const permanent = inject(PermanentService);
  const injector = inject(Injector);
  const cookieSer = inject(CookieService);
  const authentication = inject(AuthenticationService);
  const http = inject(HttpClient);

  const allowAnonymous = permanent.allowAnonymous.find((s: any) => req.url.split('?')[0].indexOf(s) > -1);

  if (req.url.includes('assets') || req.url.includes('.json')) {
    return next(req).pipe(catchError(error => throwError(() => `Error in source. Details: ${error}`)));
  } else if (allowAnonymous) {
    return next(applyUserInterfaceKey(req, permanent));
  } else {
    const universal = injector.get(UniversalService);
    return handleAuthenticatedRequest(req, next, permanent, universal, cookieSer, authentication, http);
  }
};

const handleAuthenticatedRequest = (
  req: HttpRequest<unknown>,
  next: HttpHandlerFn,
  permanent: PermanentService,
  universal: UniversalService,
  cookieSer: CookieService,
  authentication: AuthenticationService,
  http: HttpClient
): Observable<HttpEvent<unknown>> => {
  if (cookieSer.check(CookiesEnum.Token)) {
    newToken = cookieSer.get(CookiesEnum.Token);
    return sendRequest(req, next, permanent, universal, authentication);
  } else if (cookieSer.check(CookiesEnum.RefreshToken)) {
    return handleTokenRefresh(req, next, permanent, universal, authentication, http);
  } else {
    newToken = '';
    authentication.logout();
    return throwError(() => new HttpErrorResponse({ status: 401, statusText: 'No valid token available' }));
  }
};

const handleTokenRefresh = (
  req: HttpRequest<unknown>,
  next: HttpHandlerFn,
  permanent: PermanentService,
  universal: UniversalService,
  authentication: AuthenticationService,
  http: HttpClient
): Observable<HttpEvent<unknown>> => {
  if (!permanent.tokenRequestSent) {
    permanent.tokenRequestSent = true;
    queue = [];
    authentication.obtainRefreshToken().subscribe({
      next: (response: any) => {
        authentication.saveToken(response);
        newToken = response.token;
        permanent.tokenRequestSent = false;
        queue.forEach(ele => {
          execute(ele, http, universal);
        });
        queue = [];
      },
      error: (error: any) => {
        authentication.logout();
        permanent.tokenRequestSent = false;
      },
    });
  }
  return addRequestToQueue(req, next);
};

const addRequestToQueue = (req: HttpRequest<unknown>, next: HttpHandlerFn): Observable<HttpEvent<unknown>> => {
  const sub = new Subject<HttpEvent<unknown>>();
  const request = new PendingRequest(req, sub);
  queue.push(request);
  return sub.asObservable();
};

const execute = (requestData: PendingRequest, http: HttpClient, universal: UniversalService) => {
  http.request(requestData.req).subscribe({
    next: (res: HttpEvent<unknown>) => {
      requestData.subscription.next(res);
      requestData.subscription.complete();
    },
    error: err => {
      universal.loading(false);
      requestData.subscription.error(err);
      requestData.subscription.complete();
    },
  });
};

const sendRequest = (
  req: HttpRequest<unknown>,
  next: HttpHandlerFn,
  permanent: PermanentService,
  universal: UniversalService,
  authentication: AuthenticationService
): Observable<HttpEvent<unknown>> => {
  return next(applyCredentials(req, permanent)).pipe(
    catchError(error => {
      if (error instanceof HttpErrorResponse && error.status === 401) {
        universal.toastrMessage(ToastrEnum.Failed, undefined, 'Account.AutoLogout');
        authentication.logout();
      }
      return throwError(() => error);
    })
  );
};

const applyCredentials = (req: HttpRequest<unknown>, permanent: PermanentService) => {
  return req.clone({
    headers: req.headers.set('Authorization', `Bearer ${newToken}`).set('UserInterfaceKey', permanent.sysConfig.userInterfaceKey),
  });
};

const applyUserInterfaceKey = (req: HttpRequest<unknown>, permanent: PermanentService) => {
  return req.clone({
    headers: req.headers.set('UserInterfaceKey', permanent.sysConfig.userInterfaceKey),
  });
};
