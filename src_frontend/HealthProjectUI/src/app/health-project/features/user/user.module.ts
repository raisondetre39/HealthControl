import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { AnalyticsComponent } from './components/analytics/analytics.component';
import { AccountComponent } from './components/account/account.component';
import { ChartsModule } from 'ng2-charts';
import { EditUserComponent } from './components/edit-user/edit-user.component';

@NgModule({
  declarations: [AnalyticsComponent, AccountComponent, EditUserComponent],
  imports: [
    CommonModule,
    UserRoutingModule,
    SharedModule,
    ChartsModule
  ]
})
export class UserModule { }
