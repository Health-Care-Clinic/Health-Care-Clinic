import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Patient } from './ipatient';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

  private _submitRequestURL = '/api/registration-form/submit-request';

  constructor(private _http: HttpClient) { }

  submitRequest(patient:Patient): Observable<any> {

    const headers = { 'content-type': 'application/json'}  
    const body=JSON.stringify(patient);
    console.log(body)
    return this._http.post(this._submitRequestURL, body,{'headers':headers})
    
  }
}
