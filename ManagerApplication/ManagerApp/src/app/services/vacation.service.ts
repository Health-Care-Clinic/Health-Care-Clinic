import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Vacation } from '../model/vacation';

@Injectable({
  providedIn: 'root'
})
export class VacationService {
  private getAllVacationsUrl: string;
  private addNewVacationUrl: string;
  private changeVacationUrl: string;
  private deleteVacationUrl: string;
  private getAllDoctorVacationsUrl: string;
  private getPastDoctorVacationsUrl: string;
  private getCurrentDoctorVacationsUrl: string;
  private getFutureDoctorVacationsUrl: string;
  private getVacationAvailabilityUrl: string;
  private getChangedVacationAvailabilityUrl: string;

  constructor(private _http: HttpClient) {
    this.getAllVacationsUrl = '/api/vacation/getAllVacations'
    this.addNewVacationUrl = '/api/vacation/addNewVacation';
    this.changeVacationUrl = '/api/vacation/changeVacation';
    this.deleteVacationUrl = '/api/vacation/deleteVacation';
    this.getAllDoctorVacationsUrl = '/api/vacation/getVacationsByDoctorId';
    this.getPastDoctorVacationsUrl = '/api/vacation/getPastVacationsByDoctorId';
    this.getCurrentDoctorVacationsUrl = '/api/vacation/getCurrentVacationsByDoctorId';
    this.getFutureDoctorVacationsUrl = '/api/vacation/getFutureVacationsByDoctorId';
    this.getVacationAvailabilityUrl = '/api/vacation/getVacationAvailability';
    this.getChangedVacationAvailabilityUrl = '/api/vacation/getChangedVacationAvailability';
  }

  public getAllVacations() : Observable<Array<Vacation>> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.get<Array<Vacation>>(this.getAllVacationsUrl, {headers: headers});
  }

  public addVacation(vacation: Vacation) : Observable<Vacation> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.post<Vacation>(this.addNewVacationUrl, vacation, {headers: headers});
  }

  public changeVacation(vacation: Vacation) : Observable<any> {
    return this._http.put<any>(this.changeVacationUrl, vacation);
  }

  public deleteVacation(vacation: Vacation) : Observable<Vacation> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.post<Vacation>(this.deleteVacationUrl, vacation, {headers: headers});
  }

  public getAllDoctorVacations(doctorId: number) : Observable<Array<Vacation>> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.get<Array<Vacation>>(this.getAllDoctorVacationsUrl + "/" + doctorId.toString(), {headers: headers});
  }

  public getPastDoctorVacations(doctorId: number) : Observable<Array<Vacation>> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.get<Array<Vacation>>(this.getPastDoctorVacationsUrl + "/" + doctorId.toString(), {headers: headers});
  }

  public getCurrentDoctorVacations(doctorId: number) : Observable<Array<Vacation>> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.get<Array<Vacation>>(this.getCurrentDoctorVacationsUrl + "/" + doctorId.toString(), {headers: headers});
  }

  public getFutureDoctorVacations(doctorId: number) : Observable<Array<Vacation>> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.get<Array<Vacation>>(this.getFutureDoctorVacationsUrl + "/" + doctorId.toString(), {headers: headers});
  }

  public getVacationAvailability(vacation: Vacation) : Observable<boolean> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.post<boolean>(this.getVacationAvailabilityUrl, vacation, {headers: headers});
  }

  public getChangedVacationAvailability(vacation: Vacation) : Observable<boolean> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.post<boolean>(this.getChangedVacationAvailabilityUrl, vacation, {headers: headers});
  }
}
