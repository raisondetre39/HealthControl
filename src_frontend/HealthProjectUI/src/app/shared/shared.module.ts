import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MaterialModule } from './material/material.module';
import { HeaderComponent } from './layouts/header/header.component';
import { ConfirmDeleteUserDialogComponent } from './components/confirm-delete-user-dialog/confirm-delete-user-dialog.component';
import { UserService } from './services/user.service';


@NgModule({
  declarations: [HeaderComponent, ConfirmDeleteUserDialogComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    ToastrModule.forRoot(),
    MaterialModule,
  ],
  exports: [
    CommonModule,
    ReactiveFormsModule,
    HeaderComponent,
    FormsModule,
    ConfirmDeleteUserDialogComponent,
    MaterialModule,
  ]
})
export class SharedModule {
  static forRoot(): ModuleWithProviders<SharedModule> {
    return {
      ngModule: SharedModule,
      providers: [UserService]
    };
  }
}
