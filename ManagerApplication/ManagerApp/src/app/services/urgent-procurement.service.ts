import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Medicine } from '../model/medicine';

@Injectable({
  providedIn: 'root'
})
export class UrgentProcurementService {
  checkMedicine(medicineName: string, medicineAmount: string) {
    return this.http.get<boolean>('http://localhost:18089/benu/medicine/medicineExistsInQuantity?medicineName=' + medicineName +'&quantity=' + medicineAmount);
  }

  order(medicineName: string, medicineAmount: string) {
    this.http.get('http://localhost:65508/api/medicine/addMedicine?medicineName=' + medicineName +'&quantity=' + medicineAmount).subscribe();
    this.http.get('http://localhost:18089/benu/medicine/reduceMedicineQuantity?medicineName=' + medicineName +'&quantity=' + medicineAmount).subscribe();
    alert("Medicine moved!")
  }

  orderGrpc(medicine: Medicine) {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this.http.post<any>('http://localhost:65508/hospital/urgentMedicines', medicine, {headers: headers});
  }

  constructor(private http: HttpClient) { }
}
