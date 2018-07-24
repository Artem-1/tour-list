import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UrlToApi } from '../url-to-web-api';
import { Tour } from '../../Model/tour';

@Injectable({
  providedIn: 'root'
})
export class TourService {

  private baseUrl = UrlToApi + 'api/tour/';

  constructor(private http: HttpClient) { }

  getAllTours() {
    return this.http.get<Tour[]>(this.baseUrl);
  }

  getTourById(id: string) {
    return this.http.get<Tour>(this.baseUrl + id);
  }

  createTour(tour: Tour) {
    return this.http.post<Tour>(this.baseUrl, tour);
  }

  updateTour(tour: Tour) {
    return this.http.put<Tour>(this.baseUrl, tour);
  }

}
