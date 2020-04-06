import { Injectable } from '@angular/core';
import { ApiLink } from 'src/app/shared/extension/api-links';
import { HttpClient } from '@angular/common/http';
import { IUpdateUser, IUserPartialInfo, IDisease } from 'src/app/shared/interfaces/user.interface';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EditUserService {

  private apiLink = ApiLink ;
  constructor(private http: HttpClient) { }

  getUser(userId: number): Observable<IUserPartialInfo> {
    return this.http.get<IUserPartialInfo>(this.apiLink.userApi + 'Users/' + userId);
  }

  updateUser(userId: number, data: IUpdateUser) {
    return this.http.put<IUpdateUser>(this.apiLink.userApi + 'Users/' + userId, data);
  }

}
