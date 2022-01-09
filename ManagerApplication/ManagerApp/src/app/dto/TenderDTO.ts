import { Medicine } from "../model/medicine";

export interface ITenderDTO{
    id: number;
    startDate: string;
    endDate: string;
    description: string;
    isWinningBidChosen: boolean;
    price: any;
    medicines: Medicine[];
    isOpen: boolean;
    offersNumber: number;
}