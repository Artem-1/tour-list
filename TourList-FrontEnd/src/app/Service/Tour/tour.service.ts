import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UrlToApi } from '../url-to-web-api';
import { Tour } from '../../Model/tour';

@Injectable({
  providedIn: 'root'
})
export class TourService {

  private baseUrl = UrlToApi + 'api/Tour/';

  constructor(private http: HttpClient) { }

  getAllTours() {
    return this.http.get<Tour[]>(this.baseUrl);
  }

  getTour(id: string) {
    return this.http.get<Tour>(this.baseUrl + id);
  }

}
