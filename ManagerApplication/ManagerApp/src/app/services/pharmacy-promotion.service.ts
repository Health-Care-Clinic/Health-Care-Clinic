import { Injectable } from '@angular/core';
import { IPromotion } from '../model/promotion';

@Injectable({
  providedIn: 'root'
})
export class PharmacyPromotionService {

  constructor() { }

  getPostedPharmacyPromotions(): IPromotion[]{
    let promotions :IPromotion[] = this.getAllPharmacyPromotions();
    let postedPromotions :IPromotion[] = [];
    for(let p of promotions){
      if(p.Posted){
        postedPromotions.push(p);
      }
    }
    return postedPromotions;
  }

  getAllPharmacyPromotions(): IPromotion[]{
    let date = new Date();
    return [
      {
        "Id": 0,
        "Title": "Promotion 1",
        "Content": "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
        "StartDate": date,
        "EndDate": date,
        "Posted": true
      },
      {
        "Id": 1,
        "Title": "Promotion 2",
        "Content": "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
        "StartDate": date,
        "EndDate": date,
        "Posted": false
      },
      {
        "Id": 2,
        "Title": "Promotion 3",
        "Content": "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
        "StartDate": date,
        "EndDate": date,
        "Posted": false
      },
      {
        "Id": 3,
        "Title": "Promotion 4",
        "Content": "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
        "StartDate": date,
        "EndDate": date,
        "Posted": true
      },
      {
        "Id": 4,
        "Title": "Promotion 5",
        "Content": "Consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
        "StartDate": date,
        "EndDate": date,
        "Posted": true
      },
      {
        "Id": 5,
        "Title": "Promotion 6",
        "Content": "Ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
        "StartDate": date,
        "EndDate": date,
        "Posted": true
      },
      {
        "Id": 6,
        "Title": "Promotion 7",
        "Content": "Dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
        "StartDate": date,
        "EndDate": date,
        "Posted": false
      },
      {
        "Id": 7,
        "Title": "Promotion 8",
        "Content": "Asit amet, consectetur adipiscing elitpsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
        "StartDate": date,
        "EndDate": date,
        "Posted": true
      }
    ]
  }

  

}
