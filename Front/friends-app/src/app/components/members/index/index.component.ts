import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { faEye, faSearch, faEraser, faPlus } from '@fortawesome/free-solid-svg-icons';

import { MembersService } from './../../../services/members.service';

import { Paging } from './../../../../models/base/Paging';
import { Member } from './../../../../models/members/Member';
import { MembersList } from './../../../../models/members/MembersList';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html'
})
export class MembersComponent implements OnInit {
  loading: boolean = true;
  members: Member[];
  paging: Paging = new Paging();
  searchValue: string;
  faEye = faEye;
  faSearch = faSearch;
  faEraser = faEraser;
  faPlus = faPlus;

  constructor(private service: MembersService) { }

  ngOnInit(): void {
    this.getMembers(this.service.getAll());
  }


  onSubmit(event: Event) {
    event.preventDefault;
    this.getMembers(this.service.getAll(this.searchValue, 1, this.paging.perPage))
  }

  clearFilter() {
    this.searchValue = "";
    this.getMembers(this.service.getAll());
  }

  onPageChange(page: number) {
    this.getMembers(this.service.getAll(undefined, page, this.paging.perPage));
  }

  getMembers(memberListObservable: Observable<MembersList>) {
    if (!this.loading)
      this.loading = true;
    memberListObservable.subscribe(list => {
      this.members = list.items
      this.paging = list.paging;
      this.loading = false;
    });
  }

}
