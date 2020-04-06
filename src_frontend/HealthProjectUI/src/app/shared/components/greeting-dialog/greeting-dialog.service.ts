import { Injectable } from '@angular/core';
import { ApiLink } from '../../extension/api-links';
import { Observable } from 'rxjs';
import { IUserPartialInfo } from '../../interfaces/user.interface';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class GreetingDialogService {

  private apiLink = ApiLink ;
  constructor(private http: HttpClient) { }

  getUser(userId: number): Observable<IUserPartialInfo> {
    return this.http.get<IUserPartialInfo>(this.apiLink.userApi + 'Users/' + userId);
  }

}
