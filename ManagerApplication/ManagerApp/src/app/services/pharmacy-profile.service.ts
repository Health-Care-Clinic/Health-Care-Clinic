import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IApiKey } from '../model/apikey';

@Injectable({
  providedIn: 'root'
})
export class PharmacyProfileService {

  constructor(private _http: HttpClient) { }

  
  getAllPharmacies(): Observable<IApiKey[]> {
    return this._http.get<IApiKey[]>("http://localhost:65508/hospital/apikey/pharmacy-profiles");
  }

}
