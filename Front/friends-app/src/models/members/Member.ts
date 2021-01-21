import { Heading } from './Heading';

export class Member {
    id: string;
    name: string;
    website: string;
    friends: string[] | null;
    headings: Heading[] | null;
}
