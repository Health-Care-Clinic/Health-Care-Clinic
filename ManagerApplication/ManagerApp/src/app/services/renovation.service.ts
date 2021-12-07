import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Renovation } from '../model/renovation';

@Injectable({
  providedIn: 'root'
})
export class RenovationService {
  private getFreeTermsForMergeUrl: string;
  private getFreeTermsForDivideUrl: string;

  constructor(private _http: HttpClient) { 
    this.getFreeTermsForMergeUrl = '/api/renovation/getFreeTermsForMerge';
    this.getFreeTermsForDivideUrl = '/api/renovation/getFreeTermsForDivide';
  }

  public getFreeTermsForMerge(renovation:Renovation): Observable<Array<Date>> {
    return this._http.post<Array<Date>>(this.getFreeTermsForMergeUrl, renovation);
  }

  public getFreeTermsForDivide(renovation:Renovation): Observable<Array<Date>> {
    return this._http.post<Array<Date>>(this.getFreeTermsForDivideUrl, renovation);
  }
}
