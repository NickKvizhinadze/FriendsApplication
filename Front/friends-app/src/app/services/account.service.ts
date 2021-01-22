import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from './../../environments/environment';
import { MemberCreateRequest } from './../../models/members/MemberCreateRequest';
import { Member } from 'src/models/members/Member';
import { SignUpRequest } from './../../models/accounts/SignUpRequest';
import { User } from './../../models/accounts/User';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private apiBaseUrl = environment.apiBaseUrl + 'Account';
  public currentUser: User | undefined;

  constructor(private http: HttpClient) {
    var stringUser = localStorage.getItem('currentUser');
    if (stringUser)
      this.currentUser = JSON.parse(stringUser);
  }

  authorize(request: MemberCreateRequest): Observable<User> {
    return this.http.post<User>(this.apiBaseUrl + "/Authorize", request)
      .pipe(map(user => {
        if (user) {
          localStorage.setItem('currentUser', JSON.stringify(user));
          this.currentUser = user;
        }
        return user;
      }));;
  }

  register(request: SignUpRequest): Observable<any> {
    return this.http.post(this.apiBaseUrl + "/Register", request);
  }

  logout(): void {
    localStorage.removeItem('currentUser');
    this.currentUser = undefined;
  }
}
