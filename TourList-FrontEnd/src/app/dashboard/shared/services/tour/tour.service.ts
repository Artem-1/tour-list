import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { UrlToApi } from '../../../../shared/services/config-service';
import { Tour } from '../../models/tour';
import { catchError } from '../../../../../../node_modules/rxjs/operators';
import { throwError } from '../../../../../../node_modules/rxjs';

@Injectable({
  providedIn: 'root'
})
export class TourService {

  private baseUrl = UrlToApi + 'api/tour/';

  constructor(private http: HttpClient) { }

  getAllTours() {
    return this.http.get<Tour[]>(this.baseUrl).pipe(
      catchError(this.handleError)
    );
  }

  getTourById(id: string) {
    return this.http.get<Tour>(this.baseUrl + id).pipe(
      catchError(this.handleError)
    );
  }

  createTour(tour: Tour) {
    return this.http.post<Tour>(this.baseUrl, tour).pipe(
      catchError(this.handleError)
    );
  }

  updateTour(tour: Tour) {
    return this.http.put<Tour>(this.baseUrl, tour).pipe(
      catchError(this.handleError)
    );
  }

  handleError(error: HttpErrorResponse) {
    console.error(
      `Backend returned code ${error.status}, ` +
      `body was: ${error.error}`);
      
    return throwError(error);
  }
}
