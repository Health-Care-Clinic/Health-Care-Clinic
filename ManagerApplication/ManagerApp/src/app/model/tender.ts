import { Medicine } from "./medicine";

export interface ITender{
    id: number;
    startDate: Date;
    endDate: Date;
    description: string;
    isWinningBidChosen: boolean;
    price: any;
    medicines: Medicine[];
    isOpen: boolean;
    offersNumber: number;
}