import { Component } from '@angular/core';
import { GlobalService } from '../../core/utils/global.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { FixedService } from 'src/app/core/utils/fixed.service';
import { AccountService } from '../account.service';
import { SubheaderModel } from 'src/app/core/models/subheader.model';
import { ResponseEnum } from 'src/app/core/enums/response.enum';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent {
  loginForm: FormGroup;
  submitted = false;
  loading: boolean;

  constructor(
    public fixed: FixedService,
    public global: GlobalService,
    private router: Router,
    private translate: TranslateService,
    private activatedRoute: ActivatedRoute,
    private formBuilder: FormBuilder,
    private accountService: AccountService
  ) {
    this.fixed.subheader = new SubheaderModel(null, null, 'Account.SignIn');
    this.loginBefore();
  }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required, Validators.minLength(6)]],
    });
  }

  get f() {
    return this.loginForm.controls;
  }

  loginBefore() {
    if (this.accountService.isAuthenticated()) {
      this.redirect();
    }
  }

  onLoginSubmit() {
    this.submitted = true;
    if (this.loginForm.invalid) {
      return;
    }
    this.loading = true;
    this.accountService.obtainAccessToken(this.loginForm.value).subscribe({
      next: response => {
        this.loading = false;
        this.accountService.saveToken(response);
        this.redirect();
      },
      error: () => {
        this.loading = false;
        this.translate.get('Account.Incorrect').subscribe(data => {
          this.global.notificationMessage(ResponseEnum.Failed, null, data);
        });
      },
    });
  }

  redirect() {
    this.activatedRoute.queryParams.subscribe(params => {
      if (params.returnUrl != null) {
        const arr = params.returnUrl.split(';');
        var str = '{';
        for (let i = 1; i < arr.length; i++) {
          const ele = '"' + arr[i].replace('=', '":"') + '"';
          str += ele;
          if (i != arr.length - 1) str += ',';
        }
        str += '}';
        this.router.navigate([arr[0], JSON.parse(str)]);
      } else this.router.navigate(['/']);
    });
  }
}
