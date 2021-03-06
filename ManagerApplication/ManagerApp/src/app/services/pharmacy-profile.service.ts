import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IApiKey } from '../model/apikey';

@Injectable({
  providedIn: 'root'
})
export class PharmacyProfileService {
  
  
  constructor(private _http: HttpClient) { }

  getPharmacy(id: number): Observable<IApiKey> {
    return this._http.get<IApiKey>("http://localhost:65508/hospital/apikey/pharmacy-profiles/" + id);
  }
  
  getAllPharmacies(): Observable<IApiKey[]> {
    return this._http.get<IApiKey[]>("http://localhost:65508/hospital/apikey/pharmacy-profiles");
  }

  editPharmacyProfile(pharmacy: IApiKey): Observable<any> {
    return this._http.put<any>("http://localhost:65508/hospital/apikey/pharmacy-profiles", pharmacy);
  }

  uploadImage(idp: number, formData: FormData): Observable<any> {
    return this._http.post<any>("http://localhost:65508/hospital/pharmacyimage/upload-image/" + idp, formData, {reportProgress: false, observe: 'events'});
  }

  getPharmacyImage(imagePath: string): Observable<any> {

    return this._http.get<any>('http://localhost:65508/hospital/pharmacyimage/'+imagePath);

  }

}
