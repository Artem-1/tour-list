import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UrlToApi } from '../../../../shared/services/config-service';

@Injectable({
  providedIn: 'root'
})
export class ExcursionService {

  private baseUrl = UrlToApi + 'api/excursion/';

  constructor(private http: HttpClient) { }

  getAllExcursions() {
    return this.http.get<string[]>(this.baseUrl);
  }
}
