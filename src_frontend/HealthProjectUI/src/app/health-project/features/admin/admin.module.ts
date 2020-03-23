import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CreateUserComponent } from './components/create-user/create-user.component';
import { CreateUserService } from './components/create-user/create-user.service';
import { CreateDeviceComponent } from './components/create-device/create-device.component';
import { CreateDeviceService } from './components/create-device/create-device.service';


@NgModule({
  declarations: [ CreateUserComponent, CreateDeviceComponent],
  imports: [
    CommonModule,
    AdminRoutingModule,
    SharedModule
  ],
  providers: [
    CreateUserService,
    CreateDeviceService
  ]
})
export class AdminModule { }
