import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../../Model/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  baseUrl = 'http://localhost:60544/api/User';

  constructor(private http: HttpClient) { }

  getAllUsers() {
    return this.http.get<User[]>(this.baseUrl);
  }
}
