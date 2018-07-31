import { Component, OnInit } from '@angular/core';
import { Router } from '../../../../node_modules/@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  username: string;

  constructor(private router: Router) { }

  ngOnInit() {
  }

  logout()
  {
    localStorage.removeItem('auth_token');
    this.router.navigate(['login']);
  }
}
