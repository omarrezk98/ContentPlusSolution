import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class NucleusModule { }

// import { LOCALE_ID, ModuleWithProviders, NgModule } from '@angular/core';
// import { CommonModule, DatePipe, registerLocaleData } from '@angular/common';
// import { ToastrModule } from 'ngx-toastr';
// import { TranslateModule } from '@ngx-translate/core';
// import { provideHttpClient, withInterceptors } from '@angular/common/http';
// import { myHttpInterceptor } from '../utils/my-http-interceptor.service';
// import { FormsModule, ReactiveFormsModule } from '@angular/forms';
// import { NgSelectModule } from '@ng-select/ng-select';
// import { ScrolltopComponent } from '../components/theme/scrolltop/scrolltop.component';
// import { RecursiveSearchPipe } from '../pipes/recursive-search.pipe';
// import { TooltipModule } from 'ngx-bootstrap/tooltip';
// import { ThemeModeComponent } from '../components/theme/theme-mode/theme-mode.component';
// import { ChatComponent } from '../components/chat/chat.component';
// import { ChatPopupComponent } from '../components/chat/chat-popup/chat-popup.component';
// import { ChatMissedMessageComponent } from '../components/chat/chat-missed-message/chat-missed-message.component';
// import { DateDifferencePipe } from '../pipes/date-difference.pipe';
// import { FilterPipe } from '../pipes/filter.pipe';
// import { ReversePipe } from '../pipes/reverse.pipe';
// import { BsDatepickerModule, BsLocaleService } from 'ngx-bootstrap/datepicker';
// import { arLocale, defineLocale } from 'ngx-bootstrap/chronos';
// import ar from '@angular/common/locales/ar';
// import { ChangePasswordComponent } from '../components/theme/change-password/change-password.component';
// import { FooterComponent } from '../components/theme/footer/footer.component';
// import { Imageipe } from '../components/assistant/upload-image/img.pipe';
// import { UploadImageComponent } from '../components/assistant/upload-image/upload-image.component';
// import { PermissionPipe } from '../pipes/permission.pipe';
// import { RouterModule } from '@angular/router';
// import { NoDataComponent } from '../components/assistant/no-data/no-data.component';
// import { FilterByIdPipe } from '../pipes/filter-by-id.pipe';
// import { FindByIdPipe } from '../pipes/find-by-id.pipe';
// import { BsModalService } from 'ngx-bootstrap/modal';
// import { SubheaderComponent } from '../components/theme/subheader/subheader.component';
// import { ClinicBranchComponent } from '../components/assistant/clinic-branch/clinic-branch.component';
// import { ClinicLockerComponent } from '../components/assistant/clinic-locker/clinic-locker.component';
// import { ClinicRoomComponent } from '../components/assistant/clinic-room/clinic-room.component';
// import { ClinicStockComponent } from '../components/assistant/clinic-stock/clinic-stock.component';
// import { FileTypePipe } from '../pipes/file-type.pipe';
// import { FormatTimePipe } from '../pipes/format-time.pipe';
// import { ColorHexPipe } from '../pipes/color-hex.pipe';
// import { SumPipe } from '../pipes/sum.pipe';
// import { DayNamePipe } from '../pipes/day-name.pipe';

// @NgModule({
//   declarations: [
//     ScrolltopComponent,
//     ThemeModeComponent,
//     ChatComponent,
//     ChatPopupComponent,
//     ChatMissedMessageComponent,
//     ChangePasswordComponent,
//     FooterComponent,
//     UploadImageComponent,
//     NoDataComponent,
//     SubheaderComponent,
//     ClinicBranchComponent,
//     ClinicLockerComponent,
//     ClinicRoomComponent,
//     ClinicStockComponent,
//     RecursiveSearchPipe,
//     ReversePipe,
//     FilterPipe,
//     DateDifferencePipe,
//     Imageipe,
//     PermissionPipe,
//     FilterByIdPipe,
//     FindByIdPipe,
//     FileTypePipe,
//     FormatTimePipe,
//     ColorHexPipe,
//     SumPipe,
//     DayNamePipe,
//   ],
//   imports: [
//     CommonModule,
//     ToastrModule.forRoot(),
//     TranslateModule,
//     FormsModule,
//     ReactiveFormsModule,
//     RouterModule,
//     NgSelectModule,
//     TooltipModule.forRoot(),
//     BsDatepickerModule.forRoot(),
//   ],
//   exports: [
//     ToastrModule,
//     TranslateModule,
//     FormsModule,
//     ReactiveFormsModule,
//     RouterModule,
//     NgSelectModule,
//     TooltipModule,
//     BsDatepickerModule,
//     ScrolltopComponent,
//     ThemeModeComponent,
//     ChatComponent,
//     ChatMissedMessageComponent,
//     ChangePasswordComponent,
//     FooterComponent,
//     UploadImageComponent,
//     NoDataComponent,
//     SubheaderComponent,
//     ClinicBranchComponent,
//     ClinicLockerComponent,
//     ClinicRoomComponent,
//     ClinicStockComponent,
//     RecursiveSearchPipe,
//     ReversePipe,
//     FilterPipe,
//     DateDifferencePipe,
//     PermissionPipe,
//     FilterByIdPipe,
//     FindByIdPipe,
//     FileTypePipe,
//     FormatTimePipe,
//     ColorHexPipe,
//     SumPipe,
//     DayNamePipe,
//   ],
//   providers: [{ provide: LOCALE_ID, useValue: 'ar' }, provideHttpClient(withInterceptors([myHttpInterceptor])), BsLocaleService, DatePipe, BsModalService],
// })
// export class NucleusModule {
//   static forRoot(): ModuleWithProviders<NucleusModule> {
//     return {
//       ngModule: NucleusModule,
//     };
//   }
// }
// defineLocale('ar', arLocale);
// registerLocaleData(ar);
