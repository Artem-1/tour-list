import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UrlToApi } from '../../../../shared/services/config-service';
import { ExcursionSight } from '../../models/excursion-sight';

@Injectable({
  providedIn: 'root'
})
export class ExcursionSightService {

  baseUrl = UrlToApi + 'api/ExcursionSight/';

  constructor(private http: HttpClient) { }

  getAllSights() {
    return this.http.get<ExcursionSight[]>(this.baseUrl);
  }
}
