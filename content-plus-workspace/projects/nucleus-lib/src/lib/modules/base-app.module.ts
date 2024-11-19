import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class BaseAppModule { }
// import { APP_INITIALIZER, ModuleWithProviders, NgModule } from '@angular/core';
// import { HttpClient } from '@angular/common/http';
// import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
// import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
// import { TranslateHttpLoader } from '@ngx-translate/http-loader';
// import { NucleusModule } from './nucleus.module';
// import { SystemConfigService } from '../utils/system-config.service';

// export function HttpLoaderFactory(http: HttpClient) {
//   return new TranslateHttpLoader(http, './assets/i18n/', '.json');
// }

// export function loadConfigurations(configService: SystemConfigService) {
//   return () => configService.load();
// }

// @NgModule({
//   declarations: [],
//   imports: [
//     BrowserAnimationsModule,
//     NucleusModule.forRoot(),
//     TranslateModule.forRoot({
//       loader: {
//         provide: TranslateLoader,
//         useFactory: HttpLoaderFactory,
//         deps: [HttpClient],
//       },
//     }),
//   ],
//   providers: [
//     SystemConfigService,
//     {
//       provide: APP_INITIALIZER,
//       useFactory: loadConfigurations,
//       deps: [SystemConfigService], // dependancy
//       multi: true,
//     },
//   ],
// })
// export class BaseAppModule {
//   static forRoot(): ModuleWithProviders<BaseAppModule> {
//     return {
//       ngModule: BaseAppModule,
//     };
//   }
// }
