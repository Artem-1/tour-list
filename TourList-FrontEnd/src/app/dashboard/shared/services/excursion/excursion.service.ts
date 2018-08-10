import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UrlToApi } from '../../../../shared/services/config-service';
import { ExcursionSight } from '../../models/excursion-sight';

@Injectable({
  providedIn: 'root'
})
export class ExcursionService {

  private baseUrl = UrlToApi + 'api/excursion/';

  constructor(private http: HttpClient) { }

  getAllExcursions() {
    return this.http.get<string[]>(this.baseUrl);
  }

  getSights(name: string) {
    return this.http.get<ExcursionSight[]>(this.baseUrl + name);
  }
}
