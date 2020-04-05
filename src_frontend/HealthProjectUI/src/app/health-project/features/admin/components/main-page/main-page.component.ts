import { Component } from '@angular/core';
import { CreateUserComponent } from '../create-user/create-user.component';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent {

  constructor(public dialog: MatDialog) {
  }

  openFinishDialog(): void {
    const matDialogConfig = new MatDialogConfig();
    matDialogConfig.backdropClass = 'backdropBackground';
    matDialogConfig.width = '600px';
    const dialogRef = this.dialog.open(CreateUserComponent, matDialogConfig);
    dialogRef.afterClosed();
  }

}
