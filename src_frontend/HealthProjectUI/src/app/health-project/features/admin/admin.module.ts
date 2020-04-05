import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CreateUserComponent } from './components/create-user/create-user.component';
import { CreateUserService } from './components/create-user/create-user.service';
import { UserListComponent } from './components/user-list/user-list.component';
import { MainPageComponent } from './components/main-page/main-page.component';
import { UserListService } from './components/user-list/user-list.service';


@NgModule({
  declarations: [
    CreateUserComponent,
    UserListComponent,
    MainPageComponent,
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    SharedModule
  ],
  providers: [
    CreateUserService,
    UserListService,
  ]
})
export class AdminModule { }
