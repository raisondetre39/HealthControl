import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CreateUserService } from './create-user.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { IDiseaseInfo } from 'src/app/shared/interfaces/disease.interface';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.css']
})
export class CreateUserComponent implements OnInit, OnDestroy {

  userForm: FormGroup;
  disease: IDiseaseInfo;
  private destroy$ = new Subject<void>();
  constructor(private createUserService: CreateUserService,
              private toastr: ToastrService,
              private formBuilder: FormBuilder,
              private router: Router) { }

  ngOnInit(): void {
    this.getDiseases();
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
        this.toastr.error(`Something is wrong`);
      }
    );
  }

  onSubmit(): void {
    if (this.userForm.valid) {
      this.createUserService.createUser(this.userForm.value)
        .pipe(takeUntil(this.destroy$))
        .subscribe(
          (res: any) => {
            this.toastr.success(`User created successefully`, `Success`);
            this.goToCreateDevice(res.userId);
          },
          () => {
            this.toastr.error(`Something else, exam not created`, `Error`);
          }
        );
    } else {
      this.userForm.markAllAsTouched();
    }
  }

  goToCreateDevice(userId: number): void {
    this.router.navigate(['/admin/create-device', userId]);
  }

  createForm(): void  {
    this.userForm = this.formBuilder.group({
      email: [null, [Validators.required, Validators.email]],
      password: [null, Validators.required],
      firstName: [null, Validators.required],
      lastName: [null, Validators.required],
      diseaseId: [null, Validators.required]
    });
  }

  resetForm(): void {
    this.userForm.reset();
  }

  hasCustomError = (form: FormGroup, control: string): boolean =>
    form.get(`${control}`).invalid && (form.get(`${control}`).dirty || form.get(`${control}`).touched)

  hasPatternError = (form: FormGroup, control: string): boolean =>
    (form.get(`${control}`).invalid &&  form.get(`${control}`).dirty)

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

}
