import { Component, OnInit, OnDestroy } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { shareReplay, map, takeUntil } from 'rxjs/operators';
import { Breakpoints, BreakpointObserver } from '@angular/cdk/layout';
import { IUser, IUserPartialInfo } from '../../interfaces/user.interface';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/health-project/features/authentication/authentication.service';
import { Role } from '../../extension/roles';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit, OnDestroy {

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  currentUser: IUser;
  userData: IUserPartialInfo;
  private destroy$ = new Subject<void>();
  constructor(private router: Router,
              private breakpointObserver: BreakpointObserver,
              private authenticationService: AuthenticationService,
              private userService: UserService) {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
  }

  ngOnInit() {
    this.getUserInfo();
  }

  getUserInfo(): void {
    this.userService.getUser(this.currentUser.id)
      .pipe(takeUntil(this.destroy$))
      .subscribe(data => this.userData = data);
  }

  get isAdmin() {
    return this.currentUser && this.currentUser.role === Role.Admin;
  }

  get isUser() {
    return this.currentUser && this.currentUser.role === Role.User;
  }

  getRole(): string {
    if (this.isAdmin) {
      return 'Administrator';
    } else if (this.isUser) {
      return 'Patient';
    } else {
      return;
    }
  }

  userAuthenticated(): boolean {
    return this.currentUser !== null;
  }

  logout() {
    this.authenticationService.logout();
    this.router.navigate(['/login']);
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

}

