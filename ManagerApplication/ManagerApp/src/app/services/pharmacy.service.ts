import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Pharmacy } from '../dto/Pharmacy';

@Injectable({
  providedIn: 'root'
})
export class PharmacyService {
  private apiUrl: string = 'http://localhost:65508/hospital/apikey/';

  constructor(private http: HttpClient) { }

  getPharmacies() : Observable<Pharmacy[]> {
    return this.http.get<Pharmacy[]>(this.apiUrl + 'pharmacies');
  }
}
