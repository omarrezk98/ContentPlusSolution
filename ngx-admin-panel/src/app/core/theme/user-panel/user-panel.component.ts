import { Component } from '@angular/core';
import { FixedService } from '../../utils/fixed.service';

@Component({
  selector: 'app-user-panel',
  templateUrl: './user-panel.component.html',
})
export class UserPanelComponent {
  constructor(public fixed: FixedService) {}
}
