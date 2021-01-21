import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

import { MembersService } from './../../../services/members.service';

import { Paging } from './../../../../models/base/Paging';
import { Member } from './../../../../models/members/Member';
import { MembersList } from './../../../../models/members/MembersList';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html'
})
export class MembersComponent implements OnInit {
  members: Member[];
  paging: Paging = new Paging();
  searchValue: string;

  constructor(private service: MembersService) { }

  ngOnInit(): void {
    this.getPages(this.service.getAll());
  }

  getPages(memberListObservable: Observable<MembersList>) {
    memberListObservable.subscribe(list => {
      this.members = list.items
      this.paging = list.paging;
      console.log(list.items);
      console.log(list.paging);
    });
  }

}
