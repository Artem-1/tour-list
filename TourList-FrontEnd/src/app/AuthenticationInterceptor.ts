import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';
import { Router } from '@angular/router';
import { catchError } from 'rxjs/operators';
import { UserService } from './shared/services/user/user.service';

@Injectable()
export class AuthenticationInterceptor implements HttpInterceptor {

  constructor(private router: Router, private userService: UserService) { }
  
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let reqClone = request.clone({
        setHeaders: {
            Authorization: 'Bearer ' + localStorage.getItem('auth_token')
        }
    });

    return next.handle(reqClone).pipe(catchError(
      error => {
        if(error.status == 401) {
          this.userService.clearToken();
          console.log('token was expaired');
          this.router.navigate(['']);
        }
        return next.handle(request);
      }));
  }
}