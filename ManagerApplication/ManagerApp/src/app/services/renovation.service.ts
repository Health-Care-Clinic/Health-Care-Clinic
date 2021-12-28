import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Equipment } from '../model/equipment';
import { Renovation } from '../model/renovation';


@Injectable({
  providedIn: 'root'
})
export class RenovationService {
  private getAllRenovationsUrl: string;
  private addNewRenovationUrl: string;
  private getFreeTermsForMergeUrl: string;
  private getFreeTermsForDivideUrl: string;
  private getMergedRoomEquipmentUrl: string;

  constructor(private _http: HttpClient) { 
    this.getAllRenovationsUrl = 'api/renovation/getAllRenovations';
    this.addNewRenovationUrl = 'api/renovation/addNewRenovation';
    this.getFreeTermsForMergeUrl = '/api/renovation/getFreeTermsForMerge';
    this.getFreeTermsForDivideUrl = '/api/renovation/getFreeTermsForDivide';
    this.getMergedRoomEquipmentUrl = '/api/equipment/getMergedRoomEquipment';
  }

  public getAllRenovations(): Observable<Array<Renovation>> {
    return this._http.get<Array<Renovation>>(this.getAllRenovationsUrl);
  }

  public addRenovation(renovation: Renovation): Observable<Renovation> {
    return this._http.post<Renovation>(this.addNewRenovationUrl, renovation);
  } 

  public getFreeTermsForMerge(renovation:Renovation): Observable<Array<Date>> {
    return this._http.post<Array<Date>>(this.getFreeTermsForMergeUrl, renovation);
  }

  public getFreeTermsForDivide(renovation:Renovation): Observable<Array<Date>> {
    return this._http.post<Array<Date>>(this.getFreeTermsForDivideUrl, renovation);
  }

  public getMergedRoomEquipment(roomId1: number, roomId2: number): Observable<Array<Equipment>> {
    return this._http.get<Array<Equipment>>(this.getMergedRoomEquipmentUrl + "/" + roomId1 + "/" + roomId2);
  }

}
