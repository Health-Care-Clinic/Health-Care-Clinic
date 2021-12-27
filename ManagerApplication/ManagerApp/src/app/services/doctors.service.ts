import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IDoctor } from '../model/patient/doctor';

@Injectable({
  providedIn: 'root'
})
export class DoctorsService {

  private getAllDoctorsUrl: string;

  constructor(private _http: HttpClient) { 
    this.getAllDoctorsUrl = '/api/doctor/allDoctors'
  }


  public getAllDoctors(): Observable<Array<IDoctor>> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.get<Array<IDoctor>>(this.getAllDoctorsUrl, {headers: headers});
  }
}
