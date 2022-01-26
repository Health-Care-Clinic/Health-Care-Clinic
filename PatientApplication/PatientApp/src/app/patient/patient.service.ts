import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Doctor } from '../registration-form/doctor';
import { IAllergen } from '../registration-form/allergen';
import { IPatient, PatientWithPicture } from './ipatient';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import { Credentials } from './credentials';
import { IAppointment } from '../service/IAppointment';


const headers = { 'content-type': 'application/json'} 

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
  private _getAllPrescriptionsForPatient = this._patientRegistration + '/getAllPrescriptionsForPatient/';

  appointment !: IAppointment;
  
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

  getPatient(id: number): Observable<PatientWithPicture> {    
    return this._http.get<PatientWithPicture>(this._getPatient+id)
                         .do(data =>  console.log('All: ' + JSON.stringify(data)))
                         .catch(this.handleError);
  }

  submitRequest(patient:PatientWithPicture): Observable<any> {
    const body=JSON.stringify(patient);
    console.log(body)
    return this._http.post(this._submitRegistration, body)
  }

  logIn(credentials: Credentials): Observable<any> {
    const body=JSON.stringify(credentials);
    console.log(body)
    return this._http.post(this._authenticate, body,{headers, responseType: 'text'})
  }

  getAllPrescriptionsForPatient(): Observable<any> 
  {
    return this._http.get<IPatient>(this._getAllPrescriptionsForPatient + localStorage.getItem('id'))
    .do(data =>  console.log('All: ' + JSON.stringify(data)))
    .catch(this.handleError);
  }

  private handleError(err : HttpErrorResponse) {
    console.log(err.message);
    return Observable.throw(err.message);
    throw new Error('Method not implemented.');
}
}
