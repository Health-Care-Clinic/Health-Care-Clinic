export class Room {
    id: number;
    name: string;
    description: string;
    type: TypeOfRoom;
    x: number;
    y: number;
    width: number;
    height: number;
    floorId: number;

    constructor(id: number, name: string, description: string, type: TypeOfRoom, 
        x: number, y: number, width: number, height: number, floorId: number) {
            this.id = id;
            this.name = name;
            this.description = description;
            this.type = type;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.floorId = floorId;

    }
}

export enum TypeOfRoom{
    RoomForAppointments,
    OperationRoom,
    WC
}