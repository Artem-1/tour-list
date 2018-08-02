import { Component, OnInit } from '@angular/core';
import { Router } from '../../../../node_modules/@angular/router';
import { UserService } from '../../shared/services/user/user.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  user;

  constructor(private router: Router, private userService: UserService) { }

  ngOnInit() {
    this.user = JSON.parse(localStorage.getItem('currentUser')).user;
  }

  logout()
  {
    this.userService.clearToken();
    this.router.navigate(['login']);
  }
}
