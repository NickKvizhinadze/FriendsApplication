import { Component, OnInit } from '@angular/core';
import { faSignInAlt, faUser } from '@fortawesome/free-solid-svg-icons';
import { AccountService } from './services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  title = 'friends-app';
  faUser = faUser;
  faSignInAlt = faSignInAlt;

  public isCollapsed = false;

  constructor(public service: AccountService) {
  }
  ngOnInit(): void { }
}
