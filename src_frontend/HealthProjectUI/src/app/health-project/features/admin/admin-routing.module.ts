import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateUserComponent } from './components/create-user/create-user.component';
import { CreateDeviceComponent } from './components/create-device/create-device.component';


const routes: Routes = [
  { path: '', redirectTo: 'create-user', pathMatch: 'full'},
  { path: 'create-user', component: CreateUserComponent},
  { path: 'create-device/:id', component: CreateDeviceComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
