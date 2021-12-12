import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HttpParams } from '@angular/common/http';
import { ISpecification } from '../medicine-specifications/specification';

@Injectable({
  providedIn: 'root'
})
export class MedicineSpecificationService {
  private serverUrl: string = 'http://localhost:65508';

  constructor(private http: HttpClient) { }
  
  sendMessage(specification:ISpecification) {
    let params = new HttpParams(); 
    params = params.append("to", specification.to);
    params = params.append("message", specification.message);
    console.log(params);
    return this.http.get(this.serverUrl + "/hospital/medspecification/send/spec", { params: params })
  }

  downloadSpecification(specification:ISpecification) {
    let params = new HttpParams();
    params = params.append("fileName", specification.fileName);
    return this.http.get(this.serverUrl + "/hospital/medspecification/ftp", { params: params });
  }
}
