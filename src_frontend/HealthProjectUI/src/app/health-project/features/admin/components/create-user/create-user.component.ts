import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CreateUserService } from './create-user.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { IDiseaseInfo } from 'src/app/shared/interfaces/disease.interface';
import { takeUntil } from 'rxjs/operators';
import { IIndicatorInfo } from 'src/app/shared/interfaces/indicator.interface';

@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.css']
})
export class CreateUserComponent implements OnInit, OnDestroy {

  userForm: FormGroup;
  disease: IDiseaseInfo;
  deviceForm: FormGroup;
  indicator: IIndicatorInfo;
  loading = false;
  private destroy$ = new Subject<void>();
  constructor(private createUserService: CreateUserService,
              private toastr: ToastrService,
              private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.getDiseases();
    this.getIndicators();
    this.createForm();
  }

  getDiseases(): void {
    this.createUserService.getDisease()
    .pipe(takeUntil(this.destroy$))
    .subscribe(
      res => {
        this.disease = res;
      },
      () => {
        this.toastr.error(`Something else`);
      }
    );
  }

  getIndicators(): void {
    this.createUserService.getIndicators()
    .pipe(takeUntil(this.destroy$))
    .subscribe(
      res => {
        this.indicator = res;
      },
      () => {
        this.toastr.error(`Something else`);
      }
    );
  }

  onSubmit(): void {
    if (this.userForm.valid && this.deviceForm.valid) {
      this.loading = true;
      this.postUser();
    } else {
      this.userForm.markAllAsTouched();
      this.deviceForm.markAllAsTouched();
    }
  }

  postUser(): void {
    this.createUserService.createUser(this.userForm.value)
      .pipe(takeUntil(this.destroy$))
      .subscribe(
        (res: any) => {
          this.postIndicator(res.userId);
        },
        () => {
          this.loading = false;
          this.toastr.error(`Something else`, `Error`);
        }
      );
  }

  postIndicator(createdId: number): void {
    this.createUserService.createDievice({
      userId: createdId,
      ...this.deviceForm.value
    })
      .pipe(takeUntil(this.destroy$))
      .subscribe(
        () => {
          this.loading = false;
          window.location.reload();
          this.toastr.success(`User and Device created successefully`, `Success`);
        },
        () => {
          this.loading = false;
          this.deleteUser(createdId);
          this.toastr.error(`Something else`, `Error`);
        }
      );
  }

  deleteUser(userId: number) {
    this.createUserService.deleteUser(userId).subscribe(
      () => {

      },
      () => {
        this.toastr.error(`Something else, with creating user`, `Error`);
      },
    );
  }

  createForm(): void  {
    this.userForm = this.formBuilder.group({
      email: [null, [Validators.required, Validators.email]],
      password: [null, Validators.required],
      firstName: [null, Validators.required],
      lastName: [null, Validators.required],
      diseaseId: [null, Validators.required]
    });
    this.deviceForm = this.formBuilder.group({
      deviceName: [null,  Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(10)])],
      indicatorIds: [null, Validators.required],
    });
  }

  resetForm(): void {
    if (!this.loading) {
      this.userForm.reset();
      this.deviceForm.reset();
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
