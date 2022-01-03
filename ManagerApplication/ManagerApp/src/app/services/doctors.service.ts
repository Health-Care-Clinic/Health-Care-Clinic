import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IDoctor } from '../model/patient/doctor';

@Injectable({
  providedIn: 'root'
})
export class DoctorsService {

  private getAllDoctorsUrl: string;
  private addShiftToDoctor: string;

  constructor(private _http: HttpClient) { 
    this.getAllDoctorsUrl = '/api/doctor/allDoctors'
    this.addShiftToDoctor = '/api/doctor/addShiftToDoctor'
  }


  public getAllDoctors(): Observable<Array<IDoctor>> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.get<Array<IDoctor>>(this.getAllDoctorsUrl, {headers: headers});
  }

  public addShift(doctor: IDoctor, shiftId: number): Observable<IDoctor> {
    doctor.workShiftId = shiftId;
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.post<IDoctor>(this.addShiftToDoctor, doctor, {headers: headers});
  }
}
