import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IUserInfo } from 'src/app/shared/interfaces/user.interface';
import { ApiLink } from 'src/app/shared/extension/api-links';

@Injectable({
  providedIn: 'root'
})
export class UserListService {

  private apiLink = ApiLink ;
  constructor(private http: HttpClient) { }

  getUsers(): Observable<IUserInfo> {
    return this.http.get<IUserInfo>(this.apiLink.userApi + `Users`);
  }

  deleteUser(userId: number) {
    return this.http.delete(this.apiLink.userApi + `Users/` + userId);
  }
}
