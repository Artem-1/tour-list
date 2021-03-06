import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { UserService } from './shared/services/user/user.service';
import { Observable } from 'rxjs';

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private user: UserService, private router: Router) {}

  canActivate() : Observable<boolean> | Promise<boolean> | boolean {
    if(!this.user.isLoggedIn())
       this.router.navigate(['']);
       
    return true;
  }
}