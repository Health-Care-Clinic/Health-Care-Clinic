export class Feedback {
    id: number = 0;
    date: Date = new Date();
    text: string = "";
    isAnonymous: boolean = false;
    identity: string = "";
    canBePublished: boolean = true;
    isPublished: boolean = false;   
}