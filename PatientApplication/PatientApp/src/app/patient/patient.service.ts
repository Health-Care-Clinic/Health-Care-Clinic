import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Doctor } from '../registration-form/doctor';
import { IAllergen } from '../registration-form/allergen';
import { IPatient } from './ipatient';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import { Credentials } from './credentials';


const headers = { 'content-type': 'application/json',
                      'Authorization': 'Bearer ' + localStorage.getItem('jwtToken')} 

@Injectable({
  providedIn: 'root'
})

export class PatientService {

  private _patientRegistration = '/api/patient';
  private _submitRegistration  = this._patientRegistration + '/submitPatientRegistrationRequest';
  private _getAvailableDoctors = this._patientRegistration + '/getAllAvailableDoctors';
  private _getAllAllergens     = this._patientRegistration + '/getAllAllergens';
  private _getAllUsernames     = this._patientRegistration + '/getAllUsernames';
  private _getPatient          = this._patientRegistration + '/getPatient/';
  private _authenticate        = this._patientRegistration + '/authenticate';


  constructor(private _http: HttpClient) { }

  getAvailableDoctors(): Observable<Doctor[]> {
    const headers = { 'content-type': 'application/json',
                      'Authorization': 'Bearer ' + localStorage.getItem('jwtToken')} 
    return this._http.get<Doctor[]>(this._getAvailableDoctors, { 'headers': headers })
                         .do(data =>  console.log('All: ' + JSON.stringify(data)))
                         .catch(this.handleError);
  }

  getAllAllergens(): Observable<IAllergen[]> {
    const headers = { 'content-type': 'application/json',
                      'Authorization': 'Bearer ' + localStorage.getItem('jwtToken')} 
    return this._http.get<IAllergen[]>(this._getAllAllergens, { 'headers': headers })
                         .do(data =>  console.log('All: ' + JSON.stringify(data)))
                         .catch(this.handleError);
  }

  getAllUsernames(): Observable<string[]> {
    const headers = { 'content-type': 'application/json',
                      'Authorization': 'Bearer ' + localStorage.getItem('jwtToken')} 
    return this._http.get<string[]>(this._getAllUsernames, { 'headers': headers })
                         .do(data =>  console.log('All: ' + JSON.stringify(data)))
                         .catch(this.handleError);
  }

  getPatient(id: number): Observable<IPatient> {
    
    return this._http.get<IPatient>(this._getPatient+id, { 'headers': headers })
                         .do(data =>  console.log('All: ' + JSON.stringify(data)))
                         .catch(this.handleError);
  }

  submitRequest(patient:IPatient): Observable<any> {
    const headers = { 'content-type': 'application/json',
                      'Authorization': 'Bearer ' + localStorage.getItem('jwtToken')}  
    const body=JSON.stringify(patient);
    console.log(body)
    return this._http.post(this._submitRegistration, body,{'headers':headers})
  }

  logIn(credentials: Credentials): Observable<any> {
    const headers = { 'content-type': 'application/json'}
    const body=JSON.stringify(credentials);
    console.log(body)
    return this._http.post(this._authenticate, body,{headers, responseType: 'text'})
  }

  private handleError(err : HttpErrorResponse) {
    console.log(err.message);
    return Observable.throw(err.message);
    throw new Error('Method not implemented.');
}
}
