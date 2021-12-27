import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { OnCallShift } from '../model/on-call-shift';

@Injectable({
  providedIn: 'root'
})
export class OnCallShiftService {

  private getAllDoctorsOnCallShiftsUrl: string;

  constructor(private _http: HttpClient) { 
    this.getAllDoctorsOnCallShiftsUrl = '/api/onCallShift/getOnCallShiftByDoctorId'
  }

  public getAllDoctorsOnCallShifts(onCallShiftId:number): Observable<Array<OnCallShift>> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.get<Array<OnCallShift>>(this.getAllDoctorsOnCallShiftsUrl + "/"+onCallShiftId.toString(), {headers: headers});
  }
}
