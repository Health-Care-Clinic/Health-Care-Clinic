export class Transfer {
    Id: number;
    Equipment:string;
    Quantity:number;
    SourceRoomId: number;
    DestinationRoomId: number;
    Date: string;
    Duration: number;

    constructor(id: number, equipment:string, quantity: number, sourceRoomId: number, destinationRoomId: number, 
        date: string, duration: number){
        
        this.Id = id;
        this.Equipment = equipment;
        this.Quantity = quantity;
        this.SourceRoomId = sourceRoomId;
        this.DestinationRoomId = destinationRoomId;
        this.Date = date;
        this.Duration = duration;
    }
}