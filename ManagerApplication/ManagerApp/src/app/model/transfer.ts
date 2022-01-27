export class Transfer {
    id: number;
    equipment:string;
    quantity:number;
    sourceRoomId: number;
    destinationRoomId: number;
    date: Date;
    duration: number;

    constructor(id: number, equipment:string, quantity: number, sourceRoomId: number, destinationRoomId: number, 
        date: Date, duration: number){
        
        this.id = id;
        this.equipment = equipment;
        this.quantity = quantity;
        this.sourceRoomId = sourceRoomId;
        this.destinationRoomId = destinationRoomId;
        this.date = date;
        this.duration = duration;
    }
}