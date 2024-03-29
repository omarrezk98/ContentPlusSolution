import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccountRoutingModule } from './account-routing.module';
import { AccountComponent } from './account.component';
import { LoginComponent } from './login/login.component';
import { CoreModule } from '../core/core.module';

@NgModule({
  declarations: [AccountComponent, LoginComponent],
  imports: [CommonModule, AccountRoutingModule, CoreModule.forRoot()],
})
export class AccountModule {}
