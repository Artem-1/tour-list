import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UrlToApi } from '../../../../shared/services/config-service';
import { Client } from '../../models/client';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  baseUrl = UrlToApi + 'api/client/';

  constructor(private http: HttpClient) { }

  getAllClients() {
    return this.http.get<Client[]>(this.baseUrl);
  }

  getClientById(id: string) {
    return this.http.get<Client>(this.baseUrl + id)
  }

  createClient(client: Client) {
    return this.http.post<Client>(this.baseUrl, client);
  }
}
