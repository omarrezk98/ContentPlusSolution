import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './theme/header/header.component';
import { FooterComponent } from './theme/footer/footer.component';
import { LayoutComponent } from './theme/layout/layout.component';
import { TranslateModule } from '@ngx-translate/core';
import { SliderComponent } from './theme/slider/slider.component';

@NgModule({
  declarations: [HeaderComponent, FooterComponent, LayoutComponent, SliderComponent],
  imports: [CommonModule, TranslateModule],
  exports: [HeaderComponent, FooterComponent, LayoutComponent, TranslateModule],
})
export class CoreModule {
  static forRoot(): ModuleWithProviders<CoreModule> {
    return {
      ngModule: CoreModule,
    };
  }
}
