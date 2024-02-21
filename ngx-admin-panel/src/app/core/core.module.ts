import { ModuleWithProviders, NgModule, TRANSLATIONS } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FullLayoutComponent } from './theme/full-layout/full-layout.component';
import { SimpleLayoutComponent } from './theme/simple-layout/simple-layout.component';
import { HeaderComponent } from './theme/header/header.component';
import { FooterComponent } from './theme/footer/footer.component';
import { AsideComponent } from './theme/aside/aside.component';
import { ScrolltopComponent } from './theme/scrolltop/scrolltop.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { FixedService } from './utils/fixed.service';
import { TranslateModule } from '@ngx-translate/core';

const fixed = new FixedService();

@NgModule({
  declarations: [
    FullLayoutComponent,
    SimpleLayoutComponent,
    HeaderComponent,
    FooterComponent,
    AsideComponent,
    ScrolltopComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    TranslateModule,
  ],
  exports: [
    RouterModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    FullLayoutComponent,
    SimpleLayoutComponent,
    TranslateModule,
  ],
  providers: [{ provide: FixedService, useValue: fixed }],
})
export class CoreModule {
  static forRoot(): ModuleWithProviders<CoreModule> {
    return {
      ngModule: CoreModule,
    };
  }
}
