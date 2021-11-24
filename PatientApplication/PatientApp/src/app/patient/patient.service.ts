import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Doctor } from '../registration-form/doctor';
import { IAllergen } from '../registration-form/allergen';
import { IPatient } from './ipatient';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';


@Injectable({
  providedIn: 'root'
})

export class PatientService {

  private _patientRegistration = '/api/patientRegistration';
  private _submitRegistration  = this._patientRegistration + '/submitPatientRegistrationRequest';
  private _getAvailableDoctors = this._patientRegistration + '/getAllAvailableDoctors';
  private _getAllAllergens     = this._patientRegistration + '/getAllAllergens';
  private _getAllUsernames     = this._patientRegistration + '/getAllUsernames';


  constructor(private _http: HttpClient) { }

  getAvailableDoctors(): Observable<Doctor[]> {
    return this._http.get<Doctor[]>(this._getAvailableDoctors)
                         .do(data =>  console.log('All: ' + JSON.stringify(data)))
                         .catch(this.handleError);
  }

  getAllAllergens(): Observable<IAllergen[]> {
    return this._http.get<IAllergen[]>(this._getAllAllergens)
                         .do(data =>  console.log('All: ' + JSON.stringify(data)))
                         .catch(this.handleError);
  }

  getAllUsernames(): Observable<string[]> {
    return this._http.get<string[]>(this._getAllUsernames)     
                         .do(data =>  console.log('All: ' + JSON.stringify(data)))                    
                         .catch(this.handleError);
  }

  submitRequest(patient:IPatient): Observable<any> {

    const headers = { 'content-type': 'application/json'}  
    const body=JSON.stringify(patient);
    console.log(body)
    return this._http.post(this._submitRegistration, body,{'headers':headers})
  }

  private handleError(err : HttpErrorResponse) {
    console.log(err.message);
    return Observable.throw(err.message);
    throw new Error('Method not implemented.');
}
}
