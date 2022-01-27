export class Event {
    id: number;
    timestamp: Date;
    content: string;
    userId: number;

    constructor(id: number, timestamp: Date, content: string, userId: number){
        this.id = id;
        this.timestamp = timestamp;
        this.content = content;
        this.userId = userId;
    }
}
