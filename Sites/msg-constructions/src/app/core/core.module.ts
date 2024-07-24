import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './theme/header/header.component';
import { FooterComponent } from './theme/footer/footer.component';
import { LayoutComponent } from './theme/layout/layout.component';
import { TranslateModule } from '@ngx-translate/core';
import { SliderComponent } from './theme/slider/slider.component';
import { AboutUsComponent } from './theme/about-us/about-us.component';
import { ProductsComponent } from './theme/products/products.component';
import { ServicseComponent } from './theme/servicse/servicse.component';
import { CartComponent } from './theme/cart/cart.component';
import { ProductCardComponent } from './theme/product-card/product-card.component';
import { CartService } from './theme/cart/cart.service';
import { WhyUsComponent } from './theme/why-us/why-us.component';

@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent,
    LayoutComponent,
    SliderComponent,
    AboutUsComponent,
    ProductsComponent,
    ServicseComponent,
    CartComponent,
    ProductCardComponent,
    WhyUsComponent,
  ],
  imports: [CommonModule, TranslateModule],
  exports: [HeaderComponent, CartComponent, FooterComponent, LayoutComponent, TranslateModule],
  providers: [CartService],
})
export class CoreModule {
  static forRoot(): ModuleWithProviders<CoreModule> {
    return {
      ngModule: CoreModule,
    };
  }
}
