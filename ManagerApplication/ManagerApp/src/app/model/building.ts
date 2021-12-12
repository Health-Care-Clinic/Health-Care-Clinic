import { Floor } from "./floor";

export class Building {
    id: number;
    x: number;
    y: number;
    width: number;
    height: number;
    name: string;
    type: TypeOfBuilding;

    constructor(id: number,x: number,y: number,width: number,height: number,name:string,type:TypeOfBuilding){
        this.id = id;
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
        this.name = name;
        this.type = type;
    }

    
}

export enum TypeOfBuilding{
    Hospital,
    Parking
}
