import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AccountService } from './../../../services/account.service';
import { SignInRequest } from './../../../../models/accounts/SignInRequest';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html'
})
export class SigninComponent implements OnInit {
  member: SignInRequest = new SignInRequest();
  signUpForm: FormGroup;
  errors: any = {};

  constructor(private service: AccountService, private router: Router) { }

  ngOnInit(): void {
    this.signUpForm = new FormGroup({
      email: new FormControl(this.member.email, [
        Validators.required,
        Validators.minLength(4),
        Validators.email
      ]),
      password: new FormControl(this.member.password, [
        Validators.required,
      ])
    });
  }

  onSubmit(event: Event) {
    event.preventDefault;
    this.errors = {};
    if (!this.signUpForm.valid)
      return;


    this.service.authorize({ ...this.signUpForm.value, rememberMe: true }).
      subscribe(() => {
        this.router.navigate(['/home']);
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


  get email() { return this.signUpForm.get('email'); }
  get password() { return this.signUpForm.get('password'); }

}
