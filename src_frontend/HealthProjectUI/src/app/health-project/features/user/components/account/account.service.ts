import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiLink } from 'src/app/shared/extension/api-links';
import { Observable } from 'rxjs';
import { IUserPartialInfo, IDisease } from 'src/app/shared/interfaces/user.interface';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private apiLink = ApiLink ;
  constructor(private http: HttpClient) { }

  getUser(userId: number): Observable<IUserPartialInfo> {
    return this.http.get<IUserPartialInfo>(this.apiLink.userApi + 'Users/' + userId);
  }

  getDisease(diseaseId: number): Observable<IDisease> {
    return this.http.get<IDisease>(this.apiLink.diseaseApi + 'Diseases/' + diseaseId);
  }


}