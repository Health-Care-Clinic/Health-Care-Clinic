import { Medicine } from "../model/medicine";

export interface ITenderDTO{
    id: number;
    startDate: string;
    endDate: string;
    description: string;
    isWinningBidChosen: boolean;
    price: any;
    tenderItems: Medicine[];
    isOpen: boolean;
    offersNumber: number;
}