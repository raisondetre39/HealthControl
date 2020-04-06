import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AccountComponent } from './components/account/account.component';
import { AnalyticsComponent } from './components/analytics/analytics.component';


const routes: Routes = [
  { path: '', redirectTo: 'analytics', pathMatch: 'full'},
  { path: 'analytics', component: AnalyticsComponent},
  { path: 'account', component: AccountComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
