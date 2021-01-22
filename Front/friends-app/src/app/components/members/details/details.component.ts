import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable, of } from 'rxjs';
import { debounceTime, distinctUntilChanged, catchError, tap, switchMap } from 'rxjs/operators';
import { faSpinner } from '@fortawesome/free-solid-svg-icons'
import { Member } from './../../../../models/members/Member';
import { MembersService } from './../../../services/members.service';
import { Dropdown } from './../../../../models/base/Dropdown';
@Component({
  selector: 'app-details',
  templateUrl: './details.component.html'
})
export class MemberDetailsComponent implements OnInit {
  member: Member = new Member();
  loadingFriends: boolean = false;
  loadingFaild: boolean = false;
  addFriendLoading: boolean = false;
  friend: Dropdown;
  errors: any = {};
  faSpinner = faSpinner;

  constructor(private service: MembersService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route
      .params
      .subscribe(params => {
        this.service.get(params.id).subscribe(member => this.member = member);
      });
  }

  search = (text$: Observable<string>) =>
    text$.pipe(
      debounceTime(200),
      distinctUntilChanged(),
      tap(() => this.loadingFriends = true),
      switchMap(term =>
        this.service.searchFriends(term)
          .pipe(
            tap(() => {
              this.loadingFriends = false
            }),
            catchError(() => {
              this.loadingFaild = true;
              this.loadingFriends = false;
              return of([]);
            }))
      ),
    )

  addFriend = (event: Event) => {
    event.preventDefault();
    this.addFriendLoading = true;
    this.service.addFriend(this.member.id, { friendId: this.friend.value })
      .subscribe(
        () => {
          this.addFriendLoading = false;
          window.location.reload()
        },
        error => {
          this.addFriendLoading = false;
          this.errors = error.error;
        }
      )
  }


  friendFormatter(value: any) {
    return value.text;
  }

  friendInputFormatter(value: any) {
    if (value.text)
      return value.text
    return value;
  }


  getErrorKeys(): string[] {
    const keys: string[] = [];
    for (const key in this.errors) {
      if (Object.prototype.hasOwnProperty.call(this.errors, key))
        keys.push(key);
    }
    return keys;
  }


}
