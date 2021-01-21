import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { MembersComponent } from './components/members/index/index.component';
import { CreateMemberComponent } from './components/members/create/create.component';
import { MemberDetailsComponent } from './components/members/details/details.component';
import { MemberExpertsComponent } from './components/members/experts/experts.component';
import { SigninComponent } from './components/accounts/signin/signin.component';
import { SignupComponent } from './components/accounts/signup/signup.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full'
  },
  {
    path: 'home',
    pathMatch: 'full',
    component: HomeComponent
  },
  {
    path: 'members',
    pathMatch: 'full',
    component: MembersComponent
  },
  {
    path: 'members/create',
    pathMatch: 'full',
    component: CreateMemberComponent
  },
  {
    path: 'members/details/:id',
    pathMatch: 'full',
    component: MemberDetailsComponent
  },
  {
    path: 'members/experts/:id',
    pathMatch: 'full',
    component: MemberExpertsComponent
  },
  {
    path: 'signin',
    pathMatch: 'full',
    component: SigninComponent
  },
  {
    path: 'signup',
    pathMatch: 'full',
    component: SignupComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
