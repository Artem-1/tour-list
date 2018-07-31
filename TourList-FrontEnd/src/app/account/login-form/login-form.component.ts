import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Router, ActivatedRoute } from '@angular/router';

import { User } from '../../shared/models/user';
import { UserService } from '../../shared/services/user/user.service';
import { finalize } from '../../../../node_modules/rxjs/operators';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {

  email: string;
  password: string;

  private subscription: Subscription;

  brandNew: boolean;
  errors: string;
  isRequesting: boolean;
  submitted: boolean = false;

  constructor(private userService: UserService, private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.subscription = this.activatedRoute.queryParams.subscribe(
      (param: any) => {
         this.brandNew = param['password'];
         this.email = param['email'];
      });
  }

  login({ value, valid }: { value: User, valid: boolean }) {
    this.submitted = true;
    this.isRequesting = true;
    this.errors='';
    
    value.emailAddress = "mar@gmail.com";
    value.password = '12345';
    
    if (valid) {
      this.userService.login(value.emailAddress, value.password)
        .pipe(finalize(() => this.isRequesting = false))
          .subscribe(result => {
            if (result) {
              this.router.navigate(['']);
            }
          },
          error => this.errors = error);
    }
  }
}
