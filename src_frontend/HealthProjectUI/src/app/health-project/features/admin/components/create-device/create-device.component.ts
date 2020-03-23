import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { IIndicatorInfo } from 'src/app/shared/interfaces/indicator.interface';
import { Subject } from 'rxjs';
import { CreateDeviceService } from './create-device.service';
import { ToastrService } from 'ngx-toastr';
import { Router, ActivatedRoute } from '@angular/router';
import { takeUntil } from 'rxjs/operators';
import { IUserPartialInfo } from 'src/app/shared/interfaces/user.interface';

@Component({
  selector: 'app-create-device',
  templateUrl: './create-device.component.html',
  styleUrls: ['./create-device.component.css']
})
export class CreateDeviceComponent implements OnInit, OnDestroy {

  userId: number;
  deviceForm: FormGroup;
  indicator: IIndicatorInfo;
  userInfo: IUserPartialInfo;
  private destroy$ = new Subject<void>();
  constructor(private createDeviceService: CreateDeviceService,
              private toastr: ToastrService,
              private route: ActivatedRoute,
              private formBuilder: FormBuilder,
              private router: Router) { }

  ngOnInit(): void {
    this.userId = +this.route.snapshot.params.id;
    this.getUser();
    this.getIndicators();
    this.createForm();
  }

  getDiseaseName(): void {
    this.createDeviceService.getDiseaseName(this.userInfo.diseaseId)
    .pipe(takeUntil(this.destroy$))
    .subscribe(
      res => {
        this.userInfo.diseaseName = res.diseaseName;
      },
      () => {
        this.toastr.error(`Something is wrong`);
      }
    );
  }

  getUser(): void {
    this.createDeviceService.getUser(this.userId)
    .pipe(takeUntil(this.destroy$))
    .subscribe(
      res => {
        this.userInfo = res;
        this.getDiseaseName();
      },
      () => {
        this.toastr.error(`Something is wrong`);
      }
    );
  }


  getIndicators(): void {
    this.createDeviceService.getIndicators()
    .pipe(takeUntil(this.destroy$))
    .subscribe(
      res => {
        this.indicator = res;
      },
      () => {
        this.toastr.error(`Something is wrong`);
      }
    );
  }

  onSubmit(): void {
    if (this.deviceForm.valid) {
      this.createDeviceService.createDievice({
        userId: this.userId,
        ...this.deviceForm.value
      })
        .pipe(takeUntil(this.destroy$))
        .subscribe(
          (res: any) => {
            console.log(res);
            this.toastr.success(`Device assigned successefully`, `Success`);
            this.router.navigate(['/admin']);
          },
          err => {
            console.log(err);
            this.toastr.error(`Something wrong`, `Error`);
          }
        );
    } else {
      this.deviceForm.markAllAsTouched();
    }
  }

  createForm(): void  {
    this.deviceForm = this.formBuilder.group({
      deviceName: [null,  Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(10)])],
      indicatorIds: [null, Validators.required],
    });
  }

  resetForm(): void {
    this.deviceForm.reset();
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
