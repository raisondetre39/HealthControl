import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ICreateUser } from 'src/app/shared/interfaces/user.interface';
import { IDiseaseInfo } from 'src/app/shared/interfaces/disease.interface';

@Injectable({
  providedIn: 'root'
})
export class CreateUserService {

  private userApi = 'https://localhost:44390/api/';
  private diseaseApi = 'https://localhost:44377/api/';
  constructor(private http: HttpClient) { }

  createUser(data): Observable<ICreateUser> {
    return this.http.post<ICreateUser>(this.userApi + `Users`, data);
  }

  getDisease(): Observable<IDiseaseInfo> {
    return this.http.get<IDiseaseInfo>(this.diseaseApi + `Diseases`);
  }
}
