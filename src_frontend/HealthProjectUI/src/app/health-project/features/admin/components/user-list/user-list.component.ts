import { Component } from '@angular/core';
import { UserListService } from './user-list.service';
import { ToastrService } from 'ngx-toastr';
import { MatDialog } from '@angular/material/dialog';
import { Subject, BehaviorSubject } from 'rxjs';
import { takeUntil, switchMap } from 'rxjs/operators';
// tslint:disable-next-line:max-line-length
import { ConfirmDeleteUserDialogComponent } from 'src/app/shared/components/confirm-delete-user-dialog/confirm-delete-user-dialog.component';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent {
  userdeleted = false;
  userEmit$ = new BehaviorSubject('');
  userList$ = this.userEmit$.pipe(
    switchMap(() =>  this.userListService.getUsers())
  );
  private destroy$ = new Subject<void>();
  constructor(public dialog: MatDialog,
              private userListService: UserListService,
              public toastr: ToastrService) { }

  deleteUser(userId: number) {
    this.userdeleted = true;
    this.userListService.deleteUser(userId)
      .subscribe(
        () => {
          this.toastr.success('Success');
          this.userEmit$.next('');
          this.userdeleted = false;
        },
        () => {
          this.toastr.error('Error');
          this.userdeleted = false;
        }
      );
  }

  openDeleteDialog(userId: number): void {
    const dialogRef = this.dialog.open(ConfirmDeleteUserDialogComponent);
    dialogRef.afterClosed()
      .pipe(
        takeUntil(this.destroy$)
      )
      .subscribe(result => {
          if (result) {
          this.deleteUser(userId);
          }
        }
      );
  }

}
