import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Shift } from '../model/shift';

@Injectable({
  providedIn: 'root'
})
export class ShiftsService {

  private getAllShiftsUrl: string;

  constructor(private _http: HttpClient) { 
    this.getAllShiftsUrl = '/api/workDayShift/getWorkDayShifts'
  }

  public getAllShifts(): Observable<Array<Shift>> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.get<Array<Shift>>(this.getAllShiftsUrl, {headers: headers});
  }
}
