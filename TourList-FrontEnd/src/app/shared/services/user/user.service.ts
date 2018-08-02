import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { throwError } from 'rxjs';

import { UrlToApi } from '../config-service';
import { User } from '../../models/user';
import { map, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  baseUrl = UrlToApi + 'api/accounts/';
  tokenNameStorage = 'auth_token';
  userNameStorage = 'currentUser';

  constructor(private http: HttpClient) { }

  login(email: string, password: string) {
    return this.http.post<any>(this.baseUrl + 'login', { emailAddress: email, password: password })
      .pipe(
        map(res => this.saveResourses(res)),
        catchError(this.handleError)
      );
  }

  register(user: User) {
    return this.http.post<User>(this.baseUrl + "reg", user)
      .pipe(
        map(res => this.saveResourses(res)),
        catchError(this.handleError)
    );
  }

  saveResourses(res: any) {
    // login successful if there's a jwt token in the response
    if (res && res.token) {
      // store username and jwt token in local storage to keep user logged in between page refreshes
      localStorage.setItem(this.tokenNameStorage, res.token);
      localStorage.setItem(this.userNameStorage, JSON.stringify({ user: res.user }));
      return true;
    }
    return false;
  }

  clearToken() {
    localStorage.removeItem(this.tokenNameStorage);
  }

  isLoggedIn() {
    return localStorage.getItem(this.tokenNameStorage);
  }

  protected handleError(error: HttpErrorResponse) {
  // The backend returned an unsuccessful response code.
  // The response body may contain clues as to what went wrong,
  console.error(
    `Backend returned code ${error.status}, ` +
    `body was: ${error.error}`);
    
    // return an observable with a user-facing error message
    return throwError(error.error);
  }
  
}
