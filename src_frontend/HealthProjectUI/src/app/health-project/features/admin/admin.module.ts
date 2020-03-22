import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminPageComponent } from './components/admin-page/admin-page.component';
import { SharedModule } from 'src/app/shared/shared.module';


@NgModule({
  declarations: [AdminPageComponent],
  imports: [
    CommonModule,
    AdminRoutingModule,
    SharedModule
  ]
})
export class AdminModule { }
