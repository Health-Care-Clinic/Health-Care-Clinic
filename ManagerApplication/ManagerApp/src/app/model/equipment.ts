export class Equipment {
    id:number;
    name:string;
    type:EquipmentType
    quantity:number;
    roomId:number;

    constructor(id:number,name:string,type:EquipmentType,quantity:number,roomId:number){
        this.id = id;
        this.name = name;
        this.type = type;
        this.quantity = quantity;
        this.roomId = roomId;
    }
}
export enum EquipmentType{
    Static = "Static",
    Dynamic = "Dynamic"
}
