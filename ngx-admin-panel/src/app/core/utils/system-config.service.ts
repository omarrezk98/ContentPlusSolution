import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SystemConfigModel } from '../models/system-config.model';

@Injectable()
export class SystemConfigService {
  private sysConfig: SystemConfigModel;

  constructor(private http: HttpClient) {}

  public getSystemConfig(): SystemConfigModel {
    return this.sysConfig;
  }

  load() {
    return new Promise((resolve, reject) => {
      this.http.get('./system-config.json').subscribe({
        next: (response: SystemConfigModel) => {
          if (response != null) {
            this.sysConfig = response;
            this.sysConfig.domain = window.location.hostname;
            if (this.sysConfig.domain == 'localhost' || this.sysConfig.domain.includes('healthy-plus')) this.sysConfig.domain = 'app.healthy-plus.net';
          }
          resolve(true);
        },
        error: () => {},
      });
    });
  }
}
