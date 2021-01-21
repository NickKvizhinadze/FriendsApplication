import { Component } from '@angular/core';
import { faSignInAlt, faUser } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'friends-app';
  faUser = faUser;
  faSignInAlt = faSignInAlt;

  public isCollapsed = false;
}
