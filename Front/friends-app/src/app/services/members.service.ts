import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { environment } from './../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { MembersList } from './../../models/members/MembersList';

@Injectable({
  providedIn: 'root'
})
export class MembersService {
  private apiBaseUrl = environment.apiBaseUrl + 'members';
  constructor(private http: HttpClient) {
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

    return this.http.get<MembersList>(this.apiBaseUrl + queryString.slice(0, -1));
  }
}
