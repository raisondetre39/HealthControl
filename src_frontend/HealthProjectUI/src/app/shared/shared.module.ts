import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MaterialModule } from './material/material.module';
import { HeaderComponent } from './layouts/header/header.component';
import { ConfirmDeleteUserDialogComponent } from './components/confirm-delete-user-dialog/confirm-delete-user-dialog.component';
import { UserService } from './services/user.service';
import { GreetingDialogService } from './components/greeting-dialog/greeting-dialog.service';
import { GreetingDialogComponent } from './components/greeting-dialog/greeting-dialog.component';


@NgModule({
  declarations: [HeaderComponent, ConfirmDeleteUserDialogComponent, GreetingDialogComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    ToastrModule.forRoot(),
    MaterialModule,
  ],
  entryComponents: [GreetingDialogComponent],
  exports: [
    CommonModule,
    ReactiveFormsModule,
    HeaderComponent,
    FormsModule,
    ConfirmDeleteUserDialogComponent,
    GreetingDialogComponent,
    MaterialModule,
  ]
})
export class SharedModule {
  static forRoot(): ModuleWithProviders<SharedModule> {
    return {
      ngModule: SharedModule,
      providers: [UserService, GreetingDialogService]
    };
  }
}
