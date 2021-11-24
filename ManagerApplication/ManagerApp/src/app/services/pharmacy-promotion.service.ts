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

}
