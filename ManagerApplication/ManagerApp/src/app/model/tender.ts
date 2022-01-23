import { Medicine } from "./medicine";

export interface ITender{
    id: number;
    startDate: Date;
    endDate: Date;
    description: string;
    isWinningBidChosen: boolean;
    price: any;
    tenderItems: Medicine[];
    isOpen: boolean;
    offersNumber: number;
}