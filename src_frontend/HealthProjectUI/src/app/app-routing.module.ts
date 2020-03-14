import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HealthProjectComponent } from './health-project/health-project.component';


const routes: Routes = [
  {
    path: '',
    component: HealthProjectComponent,
    children: [
      {
        path: 'admin',
        loadChildren: () =>
          import('./health-project/features/admin/admin.module').then(m => m.AdminModule),
      },
      {
        path: 'login',
        loadChildren: () =>
          import('./health-project/features/authentication/authentication.module').then(m => m.AuthenticationModule)
      },
      {
        path: 'user',
        loadChildren: () =>
          import('./health-project/features/user/user.module').then(m => m.UserModule)
      },
    ]
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
      scrollPositionRestoration: 'enabled'
    })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
