import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { OnCallShift } from '../model/on-call-shift';

@Injectable({
  providedIn: 'root'
})
export class OnCallShiftService {

  private getAllDoctorsOnCallShiftsUrl: string;
  private getFreeDatesForOnCallShift: string;
  private addNewOnCallShift: string;

  constructor(private _http: HttpClient) { 
    this.getAllDoctorsOnCallShiftsUrl = '/api/onCallShift/getOnCallShiftByDoctorId'
    this.getFreeDatesForOnCallShift = '/api/onCallShift/getFreeDatesForOnCallShift'
    this.addNewOnCallShift = '/api/onCallShift/addNewOnCallShift'
  }

  public getAllDoctorsOnCallShifts(onCallShiftId:number): Observable<Array<OnCallShift>> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.get<Array<OnCallShift>>(this.getAllDoctorsOnCallShiftsUrl + "/"+onCallShiftId.toString(), {headers: headers});
  }

  public getFreeDates(month: number): Observable<Array<Date>> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.get<Array<Date>>(this.getFreeDatesForOnCallShift + "/" + month.toString(), {headers: headers});
  }

  public addOnCallShift(onCallShift:OnCallShift): Observable<OnCallShift> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.post<OnCallShift>(this.addNewOnCallShift, onCallShift, {headers: headers});
  } 
}
