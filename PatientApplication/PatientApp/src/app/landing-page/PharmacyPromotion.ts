export interface PharmacyPromotion {    
    id : number;
    title: string;
    content: string;
    pharmacyName: string;
    posted: boolean;
    startTime: Date;
    endTime: Date;
}