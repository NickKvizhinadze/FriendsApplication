import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Member } from 'src/models/members/Member';
import { Dropdown } from './../../models/base/Dropdown';
import { environment } from './../../environments/environment';
import { MembersList } from './../../models/members/MembersList';
import { MemberCreateRequest } from './../../models/members/MemberCreateRequest';
import { AddFriendRequest } from './../../models/members/AddFriendRequest';
import { ExpertsDto } from './../../models/members/ExpertsDto';
import { AccountService } from './account.service';

@Injectable({
  providedIn: 'root'
})
export class MembersService {
  private apiBaseUrl = environment.apiBaseUrl + 'Members';
  constructor(private http: HttpClient, private authService: AccountService) {
  }

  getAll(searchValue: string | undefined = undefined,
    page: number | undefined = undefined,
    perPage: number | undefined = undefined
  ): Observable<MembersList> {
    let queryString = '?';
    if (searchValue) {
      queryString += `Filter.SearchValue=${searchValue}&`;
    }

    if (page) {
      queryString += `Paging.CurrentPage=${page}&`;
    }

    if (perPage) {
      queryString += `Paging.PerPage=${perPage}&`;
    }

    return this.http.get<MembersList>(this.apiBaseUrl + queryString.slice(0, -1), {
      headers: this.authorizationHeader()
    });
  }

  get(id: string): Observable<Member> {
    return this.http.get<Member>(this.apiBaseUrl + "/" + id, { headers: this.authorizationHeader() });
  }

  searchFriends(searchValue: string): Observable<Dropdown[]> {
    if (searchValue === '') {
      return of([]);
    }
    return this.http.get<Dropdown[]>(this.apiBaseUrl + '/GetDropdownList?searchValue=' + searchValue, { headers: this.authorizationHeader() })
      .pipe(map(response => response));
  }

  getExperts(id: string, heading: string): Observable<ExpertsDto> {
    return this.http.get<ExpertsDto>(`${this.apiBaseUrl}/${id}/GetExperts?headingId=${heading}`, { headers: this.authorizationHeader() });
  }

  create(request: MemberCreateRequest): Observable<Member> {
    return this.http.post<Member>(this.apiBaseUrl, request, { headers: this.authorizationHeader() });
  }

  addFriend(id: string, request: AddFriendRequest): Observable<Member> {
    return this.http.post<Member>(`${this.apiBaseUrl}/${id}/AddFriend`, request, { headers: this.authorizationHeader() });
  }


  //region Private Methods
  private authorizationHeader(): any {
    var user = this.authService.currentUser;
    if (!user)
      return {
        'Content-Type': 'application/json'
      };
    return {
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${user.token}`
    };
  }
  //endregion
}
