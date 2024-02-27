import { ModuleWithProviders, NgModule, TRANSLATIONS } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FullLayoutComponent } from './theme/full-layout/full-layout.component';
import { SimpleLayoutComponent } from './theme/simple-layout/simple-layout.component';
import { HeaderComponent } from './theme/header/header.component';
import { FooterComponent } from './theme/footer/footer.component';
import { AsideComponent } from './theme/aside/aside.component';
import { ScrolltopComponent } from './theme/scrolltop/scrolltop.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { FixedService } from './utils/fixed.service';
import { TranslateModule } from '@ngx-translate/core';
import { Interceptor } from './utils/interceptor.service';
import { ToastrModule } from 'ngx-toastr';

const fixed = new FixedService();

@NgModule({
  declarations: [FullLayoutComponent, SimpleLayoutComponent, HeaderComponent, FooterComponent, AsideComponent, ScrolltopComponent],
  imports: [CommonModule, RouterModule, FormsModule, HttpClientModule, ReactiveFormsModule, TranslateModule, ToastrModule.forRoot()],
  exports: [RouterModule, FormsModule, HttpClientModule, ReactiveFormsModule, FullLayoutComponent, SimpleLayoutComponent, TranslateModule],
  providers: [
    { provide: FixedService, useValue: fixed },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: Interceptor,
      multi: true,
    },
  ],
})
export class CoreModule {
  static forRoot(): ModuleWithProviders<CoreModule> {
    return {
      ngModule: CoreModule,
    };
  }
}
