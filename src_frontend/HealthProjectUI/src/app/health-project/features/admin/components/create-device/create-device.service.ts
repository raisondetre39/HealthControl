import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { IDevice } from 'src/app/shared/interfaces/device.interface';
import { IIndicatorInfo } from 'src/app/shared/interfaces/indicator.interface';
import { IUserPartialInfo } from 'src/app/shared/interfaces/user.interface';

@Injectable({
  providedIn: 'root'
})
export class CreateDeviceService {

  private dieviceApi = 'https://localhost:44309/api/';
  private userApi = 'https://localhost:44390/api/';
  private diseaseApi = 'https://localhost:44377/api/';
  constructor(private http: HttpClient) { }

  createDievice(data): Observable<IDevice> {
    return this.http.post<IDevice>(this.dieviceApi + `Devices`, data);
  }

  getIndicators(): Observable<IIndicatorInfo> {
    return this.http.get<IIndicatorInfo>(this.dieviceApi + `Indicators`);
  }

  getUser(userId: number): Observable<IUserPartialInfo> {
    return this.http.get<IUserPartialInfo>(this.userApi + `Users/` + userId);
  }

  getDiseaseName(diseaseId: number): Observable<any> {
    return this.http.get<any>(this.diseaseApi + `Diseases/` + diseaseId);
  }
}
