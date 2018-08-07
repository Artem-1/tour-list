import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UrlToApi } from '../../../../shared/services/config-service';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  baseUrl = UrlToApi + 'api/client/';

  constructor(private http: HttpClient) { }

  getAllClients() {
    return this.http.get<string[]>(this.baseUrl);
  }
}
