import { Heading } from './Heading';

export class Member {
    id: number;
    name: string;
    website: string;
    friends: string[] | null;
    headings: Heading[] | null;
}
