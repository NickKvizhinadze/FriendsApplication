import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from './../../environments/environment';
import { MemberCreateRequest } from './../../models/members/MemberCreateRequest';
import { Member } from 'src/models/members/Member';
import { SignUpRequest } from './../../models/accounts/SignUpRequest';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private apiBaseUrl = environment.apiBaseUrl + 'Account';

  constructor(private http: HttpClient) { }

  authorize(request: MemberCreateRequest): Observable<Member> {
    return this.http.post<Member>(this.apiBaseUrl + "/Authorize", request);
  }

  register(request: SignUpRequest): Observable<any> {
    return this.http.post(this.apiBaseUrl + "/Register", request);
  }
}
