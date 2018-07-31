import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Response, Headers, RequestOptions } from '@angular/http';
import { Observable, BehaviorSubject } from 'rxjs';

import { UrlToApi } from '../config-service';
import { User } from '../../models/user';
import { map, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  
  baseUrl = UrlToApi + 'api/accounts/';

  constructor(private http: HttpClient) { }

  login(email: string, password: string) {
    return this.http.post<any>(this.baseUrl + 'login', { emailAddress: email, password: password })
      .pipe(map((res:any) => {
          // login successful if there's a jwt token in the response
          if (res && res.token) {
            // store username and jwt token in local storage to keep user logged in between page refreshes
            localStorage.setItem('auth_token', res.token);
            return true;
          }
        }),
        catchError(this.handleError)
      );
  }

  register(user: User) {
    return this.http.post<User>(this.baseUrl + "reg", user).pipe(
      map(res => true),
      catchError(this.handleError));
  }

  logout() {
    localStorage.removeItem('auth_token');
  }

  isLoggedIn() {
    return localStorage.getItem('auth_token');
  }
  protected handleError(error: any) {
    var applicationError = error.headers.get('Application-Error');

    // either applicationError in header or model error in body
    if (applicationError) {
      return Observable.throw(applicationError);
    }
  }
  
}
