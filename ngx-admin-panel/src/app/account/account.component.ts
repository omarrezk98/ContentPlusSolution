import { Component } from '@angular/core';
import { GlobalService } from '../core/utils/global.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
})
export class AccountComponent {
  constructor(public global: GlobalService) {}
}
