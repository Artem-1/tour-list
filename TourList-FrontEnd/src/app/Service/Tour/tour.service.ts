import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UrlToApi } from '../url-to-web-api';
import { Tour } from '../../Model/tour';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

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

  createTour(tour: Tour) {
    this.http.post<Tour>(this.baseUrl, tour);
  }

  updateTour(tour: Tour) {
    return this.http.post<Tour>(this.baseUrl, tour);
  }

}
