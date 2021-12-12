import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IPatient } from './../model/patient/patient';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

  private _patientsUrl = '/api/patient';
  private _allSuspicousPatientsUrl  = this._patientsUrl + '/allSuspiciousPatients';


  constructor(private _http: HttpClient) { }

  getAllSuspiciousPatients(): Observable<IPatient[]> {
    return this._http.get<IPatient[]>(this._allSuspicousPatientsUrl)
                         .do(data =>  console.log('All: ' + JSON.stringify(data)))
                         .catch(this.handleError);
  }

  blockPatient(patient: IPatient):Observable<any> {
    const body = JSON.stringify(patient);
    return this._http.put<any>(this._patientsUrl + '/' + patient.id, body)
  }

  private handleError(err : HttpErrorResponse) {
    console.log(err.message);
    return Observable.throw(err.message);
    throw new Error('Method not implemented.');
  }
}
