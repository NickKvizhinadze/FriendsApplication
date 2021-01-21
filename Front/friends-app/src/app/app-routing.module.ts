import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { MembersComponent } from './components/members/index/index.component';
import { CreateMemberComponent } from './components/members/create/create.component';
import { MemberDetailsComponent } from './components/members/details/details.component';

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
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
