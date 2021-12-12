
import { Room } from "./room";

export class Floor {
    id: number;
    name: string;
    rooms: Array<Room>;
    buildingId: number;

    constructor(id: number, name: string, rooms: Array<Room>, buildingId: number){
        this.id = id;
        this.name = name;
        this.rooms = rooms;
        this.buildingId = buildingId;
    }

}

