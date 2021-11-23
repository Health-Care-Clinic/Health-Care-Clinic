import { Injectable } from '@angular/core';
import { IPromotion } from '../model/promotion';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PharmacyPromotionService {

  constructor(private _http: HttpClient) { }

  getAllPromotions(): Observable<IPromotion[]> {
    return this._http.get<IPromotion[]>("http://localhost:65508/hospital/pharmacypromotion");
  }

  publishPromotion(id :number) : Observable<any>{
    return this._http.put<any>("http://localhost:65508/hospital/pharmacypromotion/"+id, null);
  }


  /*
  getPostedPharmacyPromotions(): IPromotion[]{
    let promotions :IPromotion[] = this.getAllPharmacyPromotions();
    let postedPromotions :IPromotion[] = [];
    for(let p of promotions){
      if(p.posted){
        postedPromotions.push(p);
      }
    }
    return postedPromotions;
  }

  getAllPharmacyPromotions(): IPromotion[]{
    let date = new Date();
    return [
      {
        "id": 0,
        "title": "Promotion 1",
        "content": "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
        "startDate": date,
        "endDate": date,
        "posted": true
      },
      {
        "id": 1,
        "title": "Promotion 2",
        "content": "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
        "startDate": date,
        "endDate": date,
        "posted": false
      },
      {
        "id": 2,
        "title": "Promotion 3",
        "content": "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
        "startDate": date,
        "endDate": date,
        "posted": false
      },
      {
        "id": 3,
        "title": "Promotion 4",
        "content": "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
        "startDate": date,
        "endDate": date,
        "posted": true
      },
      {
        "id": 4,
        "title": "Promotion 5",
        "content": "Consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
        "startDate": date,
        "endDate": date,
        "posted": true
      },
      {
        "id": 5,
        "title": "Promotion 6",
        "content": "Ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
        "startDate": date,
        "endDate": date,
        "posted": true
      },
      {
        "id": 6,
        "title": "Promotion 7",
        "content": "Dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
        "startDate": date,
        "endDate": date,
        "posted": false
      },
      {
        "id": 7,
        "title": "Promotion 8",
        "content": "Asit amet, consectetur adipiscing elitpsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
        "startDate": date,
        "endDate": date,
        "posted": true
      }
    ]
  }*/

  

}
