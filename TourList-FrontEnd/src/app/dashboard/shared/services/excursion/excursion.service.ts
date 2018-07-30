import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UrlToApi } from '../../../../shared/services/config-service';
import { Excursion } from '../../models/excursion';

@Injectable({
  providedIn: 'root'
})
export class ExcursionService {

  private baseUrl = UrlToApi + 'api/excursion/';

  constructor(private http: HttpClient) { }

  getAllExcursions() {
    return this.http.get<Excursion[]>(this.baseUrl);
  }

  getExcursionById(id: string) {
    return this.http.get<Excursion>(this.baseUrl + id)
  }

  createExcursion(excursion: Excursion) {
    return this.http.post<Excursion>(this.baseUrl, excursion);
  }
}
