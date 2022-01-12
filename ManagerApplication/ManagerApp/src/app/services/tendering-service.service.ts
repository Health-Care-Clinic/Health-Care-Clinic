import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ITender } from '../model/tender';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ITenderDTO } from '../dto/TenderDTO';
import { ITenderResponse } from '../model/tenderResponse';

@Injectable({
  providedIn: 'root'
})
export class TenderingServiceService {
  private serverUrl: string = 'http://localhost:5000';

  constructor(private _http: HttpClient) { }

  getAllTenders(): Observable<ITender[]> {
    return this._http.get<ITender[]>(this.serverUrl + "/api/tender");
  }

  createTender(tender: ITenderDTO) {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.post<any>(this.serverUrl + "/api/tender", tender, {headers: headers});
  }

  getPharmacyNames(startDate: string, endDate:string): Observable<string[]> {
    return this._http.get<string[]>(this.serverUrl + "/api/tender/pharmacyNames?startDate=" + startDate + "&endDate=" +  endDate);
  }

  getNumberOfWins(startDate: string, endDate:string): Observable<number[]> {
    return this._http.get<number[]>(this.serverUrl + "/api/tender/numberOfWins?startDate=" + startDate + "&endDate=" +  endDate);
  }

  getNumberOfOffers(startDate: string, endDate:string): Observable<number[]> {
    return this._http.get<number[]>(this.serverUrl + "/api/tender/numberOfOffers?startDate=" + startDate + "&endDate=" +  endDate);
  }

  getBestOffers(startDate: string, endDate:string): Observable<number[]> {
    return this._http.get<number[]>(this.serverUrl + "/api/tender/bestOffers?startDate=" + startDate + "&endDate=" +  endDate);
  }

  getTenderResponses(id: number): Observable<ITenderResponse[]> {
    return this._http.get<ITenderResponse[]>(this.serverUrl + "/api/tender/tenderResponses?tenderId=" + id);
  }

  chooseOffer(id: number) {
    return this._http.post<any>(this.serverUrl + "/api/tender/" + id, id);
  }

  getTendersNumberParticipatedByPharmacy(pharmacyName: string): Observable<number> {
    return this._http.get<number>(this.serverUrl + "/api/tender/pharmacyParticipations/" + pharmacyName);
  }

  getTendersNumberWonByPharmacy(pharmacyName: string): Observable<number> {
    return this._http.get<number>(this.serverUrl + "/api/tender/pharmacyWins/" + pharmacyName);
  }

  getPharmacyOffersForTender(pharmacyName: string, tid:number): Observable<number[]> {
    return this._http.get<number[]>(this.serverUrl + "/api/tender/PharmacyOffersForTender/" + pharmacyName + "/" + tid);
  }

  getOffersNumberByTender(tid: number): Observable<number> {
    return this._http.get<number>(this.serverUrl + "/api/tender/TenderOffersNumber/" + tid);
  }
}
