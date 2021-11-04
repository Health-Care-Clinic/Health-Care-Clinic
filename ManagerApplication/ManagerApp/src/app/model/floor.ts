
import { Room } from "./room";

export class Floor {
    id: number;
    name: string;
    rooms: Array<Room>;

    constructor(id: number, name: string, rooms: Array<Room>){
        this.id = id;
        this.name = name;
        this.rooms = rooms;
    }

}
