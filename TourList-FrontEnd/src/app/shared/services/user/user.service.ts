import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UrlToApi } from '../../services/config-service';
import { User } from '../../models/user';

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
