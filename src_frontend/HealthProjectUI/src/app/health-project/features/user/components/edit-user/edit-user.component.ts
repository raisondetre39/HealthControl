import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { IUserPartialInfo, IUser } from 'src/app/shared/interfaces/user.interface';
import { EditUserService } from './edit-user.service';
import { ToastrService } from 'ngx-toastr';
import { AuthenticationService } from '../../../authentication/authentication.service';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit, OnDestroy {

  userForm: FormGroup;
  userInfo: IUserPartialInfo;
  loading = false;
  currentUser: IUser;
  private destroy$ = new Subject<void>();
  constructor(private editUserService: EditUserService,
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
    this.editUserService.getUser(this.currentUser.id)
      .pipe(takeUntil(this.destroy$))
      .subscribe(
        (res) => {
          this.userInfo = res;
          this.initForm();
        }
      );
  }

  onSubmit(): void {
    if (this.userForm.valid) {
      this.loading = true;
      this.updateUser();
    } else {
      this.userForm.markAllAsTouched();
    }
  }

  initForm(): void {
    this.userForm.get('email').setValue(this.userInfo.email);
    this.userForm.get('firstName').setValue(this.userInfo.firstName);
    this.userForm.get('lastName').setValue(this.userInfo.lastName);
  }

  createForm(): void  {
    this.userForm = this.formBuilder.group({
      email: [null, [Validators.required, Validators.email]],
      password: [null, Validators.required],
      firstName: [null, Validators.required],
      lastName: [null, Validators.required],
    });
  }

  updateUser(): void {
    this.editUserService.updateUser(this.userInfo.id, this.userForm.value)
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
