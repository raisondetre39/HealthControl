import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Subject } from 'rxjs';
import { AccountService } from './account.service';
import { takeUntil } from 'rxjs/operators';
import { IUserPartialInfo, IUser } from 'src/app/shared/interfaces/user.interface';
import { AuthenticationService } from '../../../authentication/authentication.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { EditUserComponent } from '../edit-user/edit-user.component';
import { GreetingDialogComponent } from 'src/app/shared/components/greeting-dialog/greeting-dialog.component';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit, OnDestroy {

  userInfo: IUserPartialInfo;
  disease: string;
  currentUser: IUser;
  private destroy$ = new Subject<void>();
  constructor(private accountService: AccountService,
              public dialog: MatDialog,
              private authenticationService: AuthenticationService) {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
  }


  openDialog(): void {
    const matDialogConfig = new MatDialogConfig();
    matDialogConfig.backdropClass = 'backdropBackground';
    matDialogConfig.width = '600px';
    const dialogRef = this.dialog.open(EditUserComponent, matDialogConfig);
    dialogRef.afterClosed();
  }

  ngOnInit(): void {
    this.getUserInfo();
  }

  getUserInfo() {
    this.accountService.getUser(this.currentUser.id)
      .pipe(takeUntil(this.destroy$))
      .subscribe(
        (res) => {
          this.userInfo = res;
          this.getDiseaseInfo(this.userInfo.diseaseId);
        }
      );
  }

  getDiseaseInfo(diseaseId: number) {
    this.accountService.getDisease(diseaseId)
      .pipe(takeUntil(this.destroy$))
      .subscribe(
        (res) => {
          this.disease = res.diseaseName;
        }
      );
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }
}
