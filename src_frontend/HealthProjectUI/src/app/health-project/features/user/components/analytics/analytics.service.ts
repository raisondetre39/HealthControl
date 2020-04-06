import { Injectable } from '@angular/core';
import { ApiLink } from 'src/app/shared/extension/api-links';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IDeviceInfo } from 'src/app/shared/interfaces/user.interface';

@Injectable({
  providedIn: 'root'
})
export class AnalyticsService {

  private apiLink = ApiLink ;
  constructor(private http: HttpClient) { }

  getDevice(deviceId: number): Observable<IDeviceInfo> {
    return this.http.get<IDeviceInfo>(this.apiLink.deviceApi + 'Devices/' + deviceId);
  }

}
