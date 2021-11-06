export class Feedback {
    date: string = Date.now().toString();
    text: string = "";
    isAnonymous: boolean = false;
    identity: string = "";
    canBePublished: boolean = true;
    isPublished: boolean = false;   
}
