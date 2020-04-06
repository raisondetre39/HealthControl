import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Subject } from 'rxjs';
import { AccountService } from './account.service';
import { ToastrService } from 'ngx-toastr';
import { takeUntil } from 'rxjs/operators';
import { IUserPartialInfo, IUser } from 'src/app/shared/interfaces/user.interface';
import { AuthenticationService } from '../../../authentication/authentication.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit, OnDestroy {

  userForm: FormGroup;
  userInfo: IUserPartialInfo;
  loading = false;
  currentUser: IUser;
  private destroy$ = new Subject<void>();
  constructor(private accountService: AccountService,
              private toastr: ToastrService,
              private formBuilder: FormBuilder,
              private authenticationService: AuthenticationService) {
                this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
              }

  ngOnInit(): void {
    this.createForm();
    this.getUserInfo();
  }

  getUserInfo() {
    this.accountService.getUser(this.currentUser.id)
      .pipe(takeUntil(this.destroy$))
      .subscribe(
        (res) => {
          this.userInfo = res;
          this.initForm();
        }
      );
  }

  initForm(): void {
    this.userForm.get('email').setValue(this.userInfo.email);
    this.userForm.get('password').setValue(this.userInfo.password);
    this.userForm.get('firstName').setValue(this.userInfo.email);
    this.userForm.get('lastName').setValue(this.userInfo.email);
  }

  createForm(): void  {
    this.userForm = this.formBuilder.group({
      email: [null, [Validators.required, Validators.email]],
      password: [null, Validators.required],
      firstName: [null, Validators.required],
      lastName: [null, Validators.required],
    });
  }

  onSubmit(): void {
    if (this.userForm.valid) {
      this.loading = true;
      this.updateUser();
    } else {
      this.userForm.markAllAsTouched();
    }
  }

  updateUser(): void {
    this.accountService.updateUser(this.userInfo.id, this.userForm.value)
      .pipe(takeUntil(this.destroy$))
      .subscribe(
        () => {
          this.loading = false;
          this.toastr.success(`Success`, `Success`);
          window.location.reload();
        },
        () => {
          this.loading = false;
          this.toastr.error(`Something else`, `Error`);
        }
      );
  }

  resetForm(): void {
    if (!this.loading) {
      this.userForm.reset();
    }
  }

  hasCustomError = (form: FormGroup, control: string): boolean =>
  form.get(`${control}`).invalid && (form.get(`${control}`).dirty || form.get(`${control}`).touched)

  hasPatternError = (form: FormGroup, control: string): boolean =>
    (form.get(`${control}`).invalid && form.get(`${control}`).dirty)

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }
}
