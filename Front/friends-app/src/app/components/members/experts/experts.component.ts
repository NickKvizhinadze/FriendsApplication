import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { combineLatest } from 'rxjs';
import { map, subscribeOn } from 'rxjs/operators';
import { MembersService } from 'src/app/services/members.service';
import { ExpertsDto } from './../../../../models/members/ExpertsDto';

@Component({
  selector: 'app-experts',
  templateUrl: './experts.component.html'
})
export class MemberExpertsComponent implements OnInit {
  result: ExpertsDto = new ExpertsDto();
  memberName: string;
  constructor(private service: MembersService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    combineLatest([this.route.params, this.route.queryParams])
      .pipe(map(results => ({ id: results[0].id, heading: results[1].heading, memberName: results[1].memberName })))
      .subscribe(result => {
        this.memberName = result.memberName;
        this.service.getExperts(result.id, result.heading).subscribe(data => {
          this.result = data;
        })
      });

  }

}
