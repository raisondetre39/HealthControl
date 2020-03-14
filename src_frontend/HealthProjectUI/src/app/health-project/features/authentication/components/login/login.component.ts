import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Subject } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthenticationService } from '../../authentication.service';
import { first, map, takeUntil } from 'rxjs/operators';
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
    private toastr: ToastrService,


  ) {
    if (localStorage.getItem('currentUser')) {
      localStorage.getItem('currentUser');
      this.router.navigate(['/']);
    }
  }

  ngOnInit() {
    this.loginForm = this.formBuilder.group(
      {
        username: ['', Validators.required],
        password: ['', Validators.required]
      }
    );
    this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/';

  }
  get fields() { return this.loginForm.controls; }

  onSubmit() {
    this.submitted = true;
    if (this.loginForm.invalid) {
      return;
    }
    this.loading = true;
    this.authenticationService.login(this.loginForm)
      .pipe(map(user => {
        if (user && user.token) {
          localStorage.setItem('currentUser', JSON.stringify(user));

          this.authenticationService.currentUserSubject.next(user);

        }
      }), takeUntil(this.destroy$))
      .subscribe(
        data => {
          this.loading = false;
          console.log(this.returnUrl);
          this.router.navigate(['pass-test/select-test']);
        },
        error => {
          this.error = error;
          console.log(error + 'AQAAAAAAAAAAAAAAAAAAAAAA');
          this.loading = false;

        }
      );

  }

  login() {
    this.authenticationService.login(this.loginForm).subscribe(next => {
      this.toastr.success('Logged in succesfully');
    }, error => {
      this.toastr.error(error);
    });
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }

  hasCustomError(form: FormGroup, control: string): boolean {
    return (
      form.get(`${control}`).invalid &&
      (form.get(`${control}`).dirty || form.get(`${control}`).touched)
    );
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

}
