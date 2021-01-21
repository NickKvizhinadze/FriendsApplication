import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MembersService } from 'src/app/services/members.service';
import { MemberCreateRequest } from './../../../../models/members/MemberCreateRequest';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html'
})
export class CreateMemberComponent implements OnInit {
  member: MemberCreateRequest = new MemberCreateRequest();
  memberForm: FormGroup;
  errors: any = {};

  constructor(private service: MembersService, private router: Router) { }

  ngOnInit(): void {
    this.memberForm = new FormGroup({
      name: new FormControl(this.member.name, [
        Validators.required,
        Validators.minLength(4)
      ]),
      website: new FormControl(this.member.website, [
        Validators.required,
        Validators.minLength(4)
      ]),
    });
  }

  onSubmit(event: Event) {
    event.preventDefault;
    this.errors = {};
    if (!this.memberForm.valid)
      return;


    this.service.create(this.memberForm.value).
      subscribe(() => {
        debugger;
        this.router.navigate(['/members']);
      }, error => {
        this.errors = error.error;
      });
  }

  getErrorKeys(): string[] {
    const keys: string[] = [];
    for (const key in this.errors) {
      if (Object.prototype.hasOwnProperty.call(this.errors, key))
        keys.push(key);
    }
    return keys;
  }

  get name() { return this.memberForm.get('name'); }
  get website() { return this.memberForm.get('website'); }


}
