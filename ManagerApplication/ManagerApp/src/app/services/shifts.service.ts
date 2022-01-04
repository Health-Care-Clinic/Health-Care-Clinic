import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Shift } from '../model/shift';

@Injectable({
  providedIn: 'root'
})
export class ShiftsService {

  private getAllShiftsUrl: string;
  private addShiftUrl: string;
  private removeShiftUrl: string;

  constructor(private _http: HttpClient) { 
    this.getAllShiftsUrl = '/api/workDayShift/getWorkDayShifts';
    this.addShiftUrl = '/api/workDayShift/addWorkDayShift';
    this.removeShiftUrl = '/api/workDayShift/removeWorkDayShift';
  }

  public getAllShifts(): Observable<Array<Shift>> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.get<Array<Shift>>(this.getAllShiftsUrl, {headers: headers});
  }

  public addShift(shift: Shift): Observable<Boolean> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.post<Boolean>(this.addShiftUrl, shift, {headers: headers});
  }

  public removeShift(shift: Shift):Observable<Shift> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.post<Shift>(this.removeShiftUrl, shift, {headers: headers});
  }
}
