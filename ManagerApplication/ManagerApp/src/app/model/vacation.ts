export class Vacation {
    id: number;
    description: string;
    startTime: Date;
    endTime: Date;
    doctorId: number;

    constructor(id: number, description: string, startTime: Date, endTime: Date, doctorId: number){
        this.id = id;
        this.description = description;
        this.startTime = startTime;
        this.endTime = endTime;
        this.doctorId = doctorId;
    }
}
