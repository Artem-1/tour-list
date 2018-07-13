import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UrlToApi } from '../url-to-web-api';
import { Excursion } from '../../Model/excursion';

@Injectable({
  providedIn: 'root'
})
export class ExcursionService {

  private baseUrl = UrlToApi + 'api/Excursion';

  constructor(private http: HttpClient) { }

  getAllExcursions() {
    return this.http.get<Excursion[]>(this.baseUrl);
  }
}
