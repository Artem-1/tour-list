import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UrlToApi } from '../url-to-web-api';
import { User } from '../../Model/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  
  baseUrl = UrlToApi + 'api/User';

  constructor(private http: HttpClient) { }

  getAllUsers() {
    return this.http.get<User[]>(this.baseUrl);
  }
}
