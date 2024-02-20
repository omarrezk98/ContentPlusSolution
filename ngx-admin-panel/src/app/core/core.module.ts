import { ModuleWithProviders, NgModule } from '@angular/core';
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
  ],
  exports: [
    RouterModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    FullLayoutComponent,
    SimpleLayoutComponent,
  ],
})
export class CoreModule {
  static forRoot(): ModuleWithProviders<CoreModule> {
    return {
      ngModule: CoreModule,
    };
  }
}
