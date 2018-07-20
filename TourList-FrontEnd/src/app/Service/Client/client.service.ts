import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UrlToApi } from '../url-to-web-api';
import { Client } from '../../Model/client';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  baseUrl = UrlToApi + 'api/Client';

  constructor(private http: HttpClient) { }

  getAllClients() {
    return this.http.get<Client[]>(this.baseUrl);
  }

  createClient(name: string) {
    return this.http.post<string>(this.baseUrl, name);
  }
}
