export class Shift {
    id: number;
    name: string;
    startTime: Date;
    endTime: Date;

    constructor(id: number, name: string, startTime: Date, endTime: Date){
        this.id = id;
        this.name = name;
        this.startTime = startTime;
        this.endTime = endTime;
    }
}