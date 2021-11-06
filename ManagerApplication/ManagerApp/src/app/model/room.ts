export class Room {
    roomNumber: number;
    name: string;
    description: string;
    doctor: string;
    workHour: number;
    type: TypeOfRoom;
    x: number;
    y: number;
    width: number;
    height: number;

    constructor(roomNumber: number, name: string, description: string, doctor: string, workHour: number, type: TypeOfRoom, 
        x: number, y: number, width: number, height: number) {
            this.roomNumber = roomNumber;
            this.name = name;
            this.description = description;
            this.doctor = doctor;
            this.workHour = workHour;
            this.type = type;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
    }
}

export enum TypeOfRoom{
    RoomForAppointments = "Room for appointments",
    OperationRoom = "Operation room",
    Other = "Other"
}