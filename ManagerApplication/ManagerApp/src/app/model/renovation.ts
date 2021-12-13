export class Renovation {
    id:number;
    firstRoomId: number;
    secondRoomId: number;
    Date: Date;
    Duration: number;
    Type: TypeOfRenovation;

    constructor(id: number, firstRoomId: number, secondRoomId: number, RenovationType: TypeOfRenovation, Date: Date, 
        Duration: number){
        this.id = id;
        this.firstRoomId = firstRoomId;
        this.secondRoomId = secondRoomId;
        this.Type = RenovationType;
        this.Date = Date;
        this.Duration = Duration;
    }
}

export enum TypeOfRenovation{
    Divide,
    Merge
}