import { Component, OnInit, OnDestroy } from '@angular/core';
import { AuthenticationService } from 'src/app/health-project/features/authentication/authentication.service';
import { IUser, IUserPartialInfo } from '../../interfaces/user.interface';
import { GreetingDialogService } from './greeting-dialog.service';
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-greeting-dialog',
  templateUrl: './greeting-dialog.component.html',
  styleUrls: ['./greeting-dialog.component.css']
})

export class GreetingDialogComponent implements OnInit, OnDestroy {

  userInfo: IUserPartialInfo;
  currentUser: IUser;
  private destroy$ = new Subject<void>();
  constructor(private greetingDialogService: GreetingDialogService,
              private authenticationService: AuthenticationService) {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
  }

  ngOnInit(): void {
    this. getUserInfo();
  }

  getUserInfo() {
    this.greetingDialogService.getUser(this.currentUser.id)
      .pipe(takeUntil(this.destroy$))
      .subscribe(
        (res) => {
          console.log(res);
          this.userInfo = res;
        },
        (err) => {
          console.log(err);
        }
      );
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

}
