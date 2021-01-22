import { Component, OnInit } from '@angular/core';
import { AccountService } from './../../../services/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html'
})
export class LogoutComponent implements OnInit {

  constructor(private service: AccountService, private router: Router) {
  }
  ngOnInit(): void {
    this.service.logout();
    this.router.navigate(['/']);
  }

}
