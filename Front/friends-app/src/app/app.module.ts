import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { MembersComponent } from './components/members/index/index.component';
import { PagingComponent } from './components/shared/paging/paging.component';
import { CreateMemberComponent } from './components/members/create/create.component';
import { MemberDetailsComponent } from './components/members/details/details.component';
import { MemberExpertsComponent } from './components/members/experts/experts.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MembersComponent,
    PagingComponent,
    CreateMemberComponent,
    MemberDetailsComponent,
    MemberExpertsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule,
    FontAwesomeModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
