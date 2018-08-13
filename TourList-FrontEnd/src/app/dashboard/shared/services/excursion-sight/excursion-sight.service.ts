import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UrlToApi } from '../../../../shared/services/config-service';

@Injectable()
export class ExcursionSightService {

  baseUrl = UrlToApi + 'api/ExcursionSight/';

  constructor(private http: HttpClient) { }

  getAllSights() {
    return this.http.get<string[]>(this.baseUrl);
  }
}
