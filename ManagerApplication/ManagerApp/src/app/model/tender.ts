import { Medicine } from "./medicine";

export interface ITender{
    id: number;
    startDate: Date;
    endDate: Date;
    description: string;
    isWinningBidChosen: string;
    price: any;
    medicines: Medicine[];
}