import { Component, OnInit } from '@angular/core';
import { IUser } from '../shared/interfaces/user.interface';
import { AuthenticationService } from './features/authentication/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-health-project',
  templateUrl: './health-project.component.html',
  styleUrls: ['./health-project.component.css']
})
export class HealthProjectComponent implements OnInit {

  currentUser: IUser;

  constructor(private router: Router,
              private authenticationService: AuthenticationService) {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
  }

  ngOnInit() {
    if (!this.userAuthenticated()) {
      this.router.navigate(['/login']);
    }
  }

  userAuthenticated(): boolean {
    return this.currentUser !== null;
  }

}
