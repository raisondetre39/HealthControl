import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Subject } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from '../../authentication.service';
import { first } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit, OnDestroy {

  loginForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;
  error: '';
  jwtHelper = new JwtHelperService();

  private destroy$ = new Subject<void>();
  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService,
  ) {
    if (this.authenticationService.currentUserValue) {
      this.router.navigate(['/']);
    }
  }

  ngOnInit() {
    this.generateForm();
    this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/';
  }

  generateForm() {
    this.loginForm = this.formBuilder.group(
      {
        email: ['', [Validators.required, Validators.email]],
        password: ['', Validators.required]
      }
    );
  }
  get fields() { return this.loginForm.controls; }

  onSubmit() {
    this.submitted = true;
    if (this.loginForm.valid) {
    this.loading = true;
    this.authenticationService.login(this.loginForm)
    .pipe(first())
    .subscribe(
        () => {
          this.router.navigate([this.returnUrl]);
        },
        error => {
            this.error = error;
            this.loading = false;
        });
    } else {
        this.loginForm.markAllAsTouched();
    }
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
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
