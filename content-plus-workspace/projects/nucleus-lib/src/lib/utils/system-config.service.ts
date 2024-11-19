import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class SystemConfigService {
  private sysConfig: any;

  constructor(private http: HttpClient) {}

  public getSystemConfig(): any {
    return this.sysConfig!;
  }

  load() {
    return new Promise((resolve, reject) => {
      this.http.get('./assets/system-config.json').subscribe({
        next: (response: any) => {
          if (response != null) {
            this.sysConfig = response;
          }
          resolve(true);
        },
        error: error => {},
      });
    });
  }
}
