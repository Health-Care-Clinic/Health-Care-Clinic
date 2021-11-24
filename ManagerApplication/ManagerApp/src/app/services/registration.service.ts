import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IApiKey } from '../registration/pharmacy-registration/apikey';

@Injectable({
  providedIn: 'root'
})
export class RegistrationService {
  private serverUrl: string = 'http://localhost:65508';
  constructor(private http: HttpClient) { 

  }
  registerPharmacy(apikey:IApiKey): Observable<any> {
    return this.http.post<any>(this.serverUrl + "/hospital/apikey", apikey);
  }
}
