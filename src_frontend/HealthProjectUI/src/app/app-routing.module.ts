import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HealthProjectComponent } from './health-project/health-project.component';
import { AuthGuard } from './health-project/guards/auth.guard';
import { Role } from './shared/extension/roles';


const routes: Routes = [
  {
    path: '',
    component: HealthProjectComponent,
    children: [
      {
        path: '',
        redirectTo: 'home',
        pathMatch: 'full'
      },
      {
        path: 'home',
        loadChildren: () =>
          import('./health-project/features/home/home.module').then(m => m.HomeModule)
      },
      {
        path: 'admin',
        loadChildren: () =>
          import('./health-project/features/admin/admin.module').then(m => m.AdminModule),
        canActivate: [AuthGuard],
        data: { roles: [Role.Admin] }
      },
      {
        path: 'user',
        loadChildren: () =>
          import('./health-project/features/user/user.module').then(m => m.UserModule)
      },
    ]
  },
  {
    path: 'login',
    loadChildren: () =>
      import('./health-project/features/authentication/authentication.module').then(m => m.AuthenticationModule)
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
