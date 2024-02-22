import { Component } from '@angular/core';
import { GlobalService } from '../core/utils/global.service';
import { FixedService } from '../core/utils/fixed.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
})
export class AccountComponent {
  constructor(public global: GlobalService, public fixed: FixedService) {}
}
