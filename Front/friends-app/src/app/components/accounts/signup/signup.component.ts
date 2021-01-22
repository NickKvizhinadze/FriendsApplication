import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { faSpinner } from '@fortawesome/free-solid-svg-icons'
import { AccountService } from './../../../services/account.service';
import { SignUpRequest } from './../../../../models/accounts/SignUpRequest';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html'
})
export class SignupComponent implements OnInit {
  loading: boolean = false;
  member: SignUpRequest = new SignUpRequest();
  signUpForm: FormGroup;
  errors: any = {};
  faSpinner = faSpinner;

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
        Validators.minLength(6)
      ]),
      confirmPassword: new FormControl(this.member.confirmPassword, [
        Validators.required,
        Validators.minLength(6)
      ]),
    });
  }

  onSubmit(event: Event) {
    event.preventDefault;
    this.loading = true;
    this.errors = {};
    if (!this.signUpForm.valid) {
      this.loading = false;
      return;
    }


    this.service.register(this.signUpForm.value).
      subscribe(() => {
        this.router.navigate(['/signin']);
        this.loading = false;
      }, error => {
        this.errors = error.error;
        this.loading = false;
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
  get confirmPassword() { return this.signUpForm.get('confirmPassword'); }

}
