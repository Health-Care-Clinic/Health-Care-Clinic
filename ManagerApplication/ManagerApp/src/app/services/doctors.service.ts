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
  private getNumOfAppUrl: string;
  private getNumOfPatUrl: string;
  
  
  constructor(private _http: HttpClient) { 
    this.getAllDoctorsUrl = '/api/doctor/allDoctors'
    this.getNumOfAppUrl = '/api/doctor/getNumOfAppointments'
    this.getNumOfPatUrl = '/api/doctor/getNumOfPatients'
    this.addShiftToDoctor = '/api/doctor/addShiftToDoctor'
  }


  public getAllDoctors(): Observable<Array<IDoctor>> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.get<Array<IDoctor>>(this.getAllDoctorsUrl, {headers: headers});
  }

  public getNumOfPatients(id:number,month:number,year:number): Observable<number> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.get<number>(this.getNumOfPatUrl + "/"+ id + "/" + month + "/" + year, {headers: headers});
  }
  
  public getNumOfAppointments(id:number,month:number,year:number): Observable<number> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.get<number>(this.getNumOfAppUrl + "/"+ id + "/" + month + "/" + year, {headers: headers});
  }

  public addShift(doctor: IDoctor, shiftId: number): Observable<IDoctor> {
    doctor.workShiftId = shiftId;
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.post<IDoctor>(this.addShiftToDoctor, doctor, {headers: headers});
  }
}
