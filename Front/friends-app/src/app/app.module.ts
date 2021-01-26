import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app-routing.module';
import { ErrorInterceptor } from './helpers/error.interceptor';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { MembersComponent } from './components/members/index/index.component';
import { PagingComponent } from './components/shared/paging/paging.component';
import { CreateMemberComponent } from './components/members/create/create.component';
import { MemberDetailsComponent } from './components/members/details/details.component';
import { MemberExpertsComponent } from './components/members/experts/experts.component';
import { SigninComponent } from './components/accounts/signin/signin.component';
import { SignupComponent } from './components/accounts/signup/signup.component';
import { LogoutComponent } from './components/accounts/logout/logout.component';
import { LoaderComponent } from './components/shared/loader/loader.component';
import { ErrorComponent } from './components/shared/error/error.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MembersComponent,
    PagingComponent,
    CreateMemberComponent,
    MemberDetailsComponent,
    MemberExpertsComponent,
    SigninComponent,
    SignupComponent,
    LogoutComponent,
    LoaderComponent,
    ErrorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule,
    FontAwesomeModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
