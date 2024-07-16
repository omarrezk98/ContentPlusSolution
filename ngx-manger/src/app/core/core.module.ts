import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AsideComponent } from './theme/aside/aside.component';
import { FooterComponent } from './theme/footer/footer.component';
import { FullLayoutComponent } from './theme/full-layout/full-layout.component';
import { HeaderComponent } from './theme/header/header.component';
import { ScrolltopComponent } from './theme/scrolltop/scrolltop.component';
import { SimpleLayoutComponent } from './theme/simple-layout/simple-layout.component';
import { UserPanelComponent } from './theme/user-panel/user-panel.component';

@NgModule({
  declarations: [
    AsideComponent,
    FooterComponent,
    FullLayoutComponent,
    HeaderComponent,
    ScrolltopComponent,
    SimpleLayoutComponent,
    UserPanelComponent,
  ],
  imports: [CommonModule],
})
export class CoreModule {
  static forRoot():
    | any[]
    | import('@angular/core').Type<any>
    | import('@angular/core').ModuleWithProviders<{}> {
    throw new Error('Method not implemented.');
  }
}
