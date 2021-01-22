import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { faSpinner } from '@fortawesome/free-solid-svg-icons'
import { MembersService } from 'src/app/services/members.service';
import { MemberCreateRequest } from './../../../../models/members/MemberCreateRequest';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html'
})
export class CreateMemberComponent implements OnInit {
  loading: boolean = false;
  member: MemberCreateRequest = new MemberCreateRequest();
  memberForm: FormGroup;
  errors: any = {};
  faSpinner = faSpinner;

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
    this.loading = true;
    this.errors = {};
    if (!this.memberForm.valid) {
      this.loading = false;
      return;
    }


    this.service.create(this.memberForm.value).
      subscribe(() => {
        this.loading = false;
        this.router.navigate(['/members']);
      }, error => {
        this.loading = false;
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
