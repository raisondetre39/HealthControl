import { Injectable } from '@angular/core';
import { ApiLink } from '../extension/api-links';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IUserPartialInfo } from '../interfaces/user.interface';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private apiLink = ApiLink ;
  constructor(private http: HttpClient) { }

  getUser(userId: number): Observable<IUserPartialInfo> {
    return this.http.get<IUserPartialInfo>(this.apiLink.userApi + `Users/` + userId);
  }

}
