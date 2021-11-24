import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

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

  constructor(private http: HttpClient) { }
}
