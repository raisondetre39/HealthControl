import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ICreateUser } from 'src/app/shared/interfaces/user.interface';
import { IDiseaseInfo } from 'src/app/shared/interfaces/disease.interface';
import { ApiLink } from 'src/app/shared/extension/api-links';
import { IDevice } from 'src/app/shared/interfaces/device.interface';
import { IIndicatorInfo } from 'src/app/shared/interfaces/indicator.interface';

@Injectable({
  providedIn: 'root'
})
export class CreateUserService {

  private apiLink = ApiLink ;
  constructor(private http: HttpClient) { }

  createUser(data): Observable<ICreateUser> {
    return this.http.post<ICreateUser>(this.apiLink.userApi + `Users`, data);
  }

  getDisease(): Observable<IDiseaseInfo> {
    return this.http.get<IDiseaseInfo>(this.apiLink.diseaseApi + `Diseases`);
  }

  createDievice(data): Observable<IDevice> {
    return this.http.post<IDevice>(this.apiLink.dieviceApi + `Devices`, data);
  }

  getIndicators(): Observable<IIndicatorInfo> {
    return this.http.get<IIndicatorInfo>(this.apiLink.dieviceApi + `Indicators`);
  }

  deleteUser(userId: number) {
    return this.http.delete(this.apiLink.userApi + `Users/` + userId);
  }
}
