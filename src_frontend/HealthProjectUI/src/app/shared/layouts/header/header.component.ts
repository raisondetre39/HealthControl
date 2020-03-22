import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { shareReplay, map } from 'rxjs/operators';
import { Breakpoints, BreakpointObserver } from '@angular/cdk/layout';
import { IUser } from '../../interfaces/user.interface';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/health-project/features/authentication/authentication.service';
import { Role } from '../../extension/roles';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  currentUser: IUser;

  constructor(private router: Router,
              private breakpointObserver: BreakpointObserver,
              private authenticationService: AuthenticationService) {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
  }

  get isAdmin() {
    return this.currentUser && this.currentUser.role === Role.Admin;
  }

  userAuthenticated(): boolean {
    return this.currentUser !== null;
  }

  logout() {
    this.authenticationService.logout();
    this.router.navigate(['/login']);
  }

}

