import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthenticationRoutingModule } from './authentication-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { AuthenticationService } from './authentication.service';
import { LoginComponent } from './components/login/login.component';


@NgModule({
  declarations: [LoginComponent],
  imports: [
    CommonModule,
    AuthenticationRoutingModule,
    SharedModule,
  ],
  providers: [
  ]
})
export class AuthenticationModule { }
