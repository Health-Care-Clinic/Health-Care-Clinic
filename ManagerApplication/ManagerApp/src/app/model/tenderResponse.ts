import { Medicine } from "./medicine";

export interface ITenderResponse {
    id: number;
    tenderId: number;
    pharmacyName: string;
    description: string;
    totalPrice: number;
    isWinningBid: boolean;
    tenderItems: Medicine[];
}