import { ModuleWithProviders, NgModule } from '@angular/core';
import { SimpleLayoutComponent } from './theme/simple-layout/simple-layout.component';
import { FullLayoutComponent } from './theme/full-layout/full-layout.component';
import { HeaderComponent } from './theme/header/header.component';
import { FooterComponent } from './theme/footer/footer.component';
import { AsideComponent } from './theme/aside/aside.component';
import { ScrolltopComponent } from './theme/scrolltop/scrolltop.component';
import { NucleusModule } from 'projects/nucleus-lib/src/lib/modules/nucleus.module';

@NgModule({
  declarations: [FullLayoutComponent, SimpleLayoutComponent, HeaderComponent, FooterComponent, AsideComponent, ScrolltopComponent, UserPanelComponent],
  exports: [ FullLayoutComponent, SimpleLayoutComponent],
  imports:[NucleusModule.forRoot()]

})
export class CoreModule {
}
