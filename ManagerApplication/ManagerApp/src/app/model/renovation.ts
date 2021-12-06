export class Renovation {
    DivideRoom: number;
    MergeRoom1: number;
    MergeRoom2: number;
    RenovationType: TypeOfRenovation;
    Date: Date;
    Duration: number;
    TypeOfNewRoom: String;
    NameOfNewRoom: String;
    DescriptionOfNewRoom: String;

    constructor(DivideRoom: number, MergeRoom1: number, MergeRoom2: number, RenovationType: TypeOfRenovation, Date: Date, 
        Duration: number, TypeOfNewRoom: String, NameOfNewRoom: String, DescriptionOfNewRoom: String){
        
        this.DivideRoom = DivideRoom;
        this.MergeRoom1 = MergeRoom1;
        this.MergeRoom2 = MergeRoom2;
        this.RenovationType = RenovationType;
        this.Date = Date;
        this.Duration = Duration;
        this.TypeOfNewRoom = TypeOfNewRoom;
        this.NameOfNewRoom = NameOfNewRoom;
        this.DescriptionOfNewRoom = DescriptionOfNewRoom;
    }
}

export enum TypeOfRenovation{
    Merge,
    Divide
}