import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';

@Injectable()
export class AuthenticationInterceptor implements HttpInterceptor {
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    //req.headers.append('Authorization', 'Bearer ' + localStorage.getItem('auth_token'))
    request = request.clone({
        setHeaders: {
            Authorization: 'Bearer ' + localStorage.getItem('auth_token')
        }
    });
    return next.handle(request);
  }
}