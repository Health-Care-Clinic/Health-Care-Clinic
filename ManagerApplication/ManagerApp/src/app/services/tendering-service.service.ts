import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ITender } from '../model/tender';

@Injectable({
  providedIn: 'root'
})
export class TenderingServiceService {

  constructor(private _http: HttpClient) { }

  getAllTenders(): Observable<ITender[]> {
    return this._http.get<ITender[]>("https://localhost:44360/api/tender");
  }
}
