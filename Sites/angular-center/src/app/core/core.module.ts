import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './theme/header/header.component';
import { FooterComponent } from './theme/footer/footer.component';
import { LayoutComponent } from './theme/layout/layout.component';
import { SliderComponent } from './theme/slider/slider.component';
import { BlogComponent } from './theme/blog/blog.component';
import { AboutComponent } from './theme/about/about.component';
import { ContactUsComponent } from './theme/contact-us/contact-us.component';

@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent,
    LayoutComponent,
    SliderComponent,
    BlogComponent,
    AboutComponent,
    ContactUsComponent,
  ],
  imports: [CommonModule],
  exports: [HeaderComponent, FooterComponent, LayoutComponent],
})
export class CoreModule {
  static forRoot(): ModuleWithProviders<CoreModule> {
    return {
      ngModule: CoreModule,
    };
  }
}
