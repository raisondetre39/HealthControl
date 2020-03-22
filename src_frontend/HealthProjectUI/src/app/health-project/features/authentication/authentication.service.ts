import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { IUser } from 'src/app/shared/interfaces/user.interface';
import { environment } from 'src/environments/environment.prod';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private currentUserSubject: BehaviorSubject<IUser>;
  public currentUser: Observable<IUser>;

  constructor(private http: HttpClient) {
    this.currentUserSubject = new BehaviorSubject<IUser>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue(): IUser {
    return this.currentUserSubject.value;
  }

  login(form): Observable<any> {
    return this.http.post<any>(`https://localhost:44389/api/authentication`, form.value)
    .pipe(map(user => {
      if (user && user.token) {
          localStorage.setItem('currentUser', JSON.stringify(user));
          this.currentUserSubject.next(user);
      }
      return user;
    }));
  }

  logout() {
    localStorage.removeItem('currentUser');
    this.currentUserSubject.next(null);
  }

  getToken() {
    return localStorage.getItem('currentUser');
  }
}
