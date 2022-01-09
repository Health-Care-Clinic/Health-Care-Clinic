import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Credentials } from '../model/manager/credentials';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private _managerRegistartion = '/api/patient'; // MOZDA OVO PROMENITI!!
  private _authenticate        = this._managerRegistartion + '/authenticate';

  constructor(private _http: HttpClient) { }

  logIn(credentials: Credentials): Observable<any> {
    const headers = { 'content-type': 'application/json'}
    const body=JSON.stringify(credentials);
    console.log(body)
    return this._http.post(this._authenticate, body,{headers, responseType: 'text'})
  }
}
