import { ExpertDto } from 'src/models/members/ExpertDto';

export class ExpertsDto {
    memberId: string;
    memberName: string;
    headingId: string;
    headingValue: string;
    experts: ExpertDto[]
}
