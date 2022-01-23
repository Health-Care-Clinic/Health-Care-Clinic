import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Pharmacy } from 'src/app/dto/Pharmacy';
import { Medicine } from 'src/app/model/medicine';
import { PharmacyService } from 'src/app/services/pharmacy.service';
import { UrgentProcurementService } from 'src/app/services/urgent-procurement.service';
import { OrderDialogComponent } from './order-dialog/order-dialog.component';

@Component({
  selector: 'app-urgent-procurement',
  templateUrl: './urgent-procurement.component.html',
  styleUrls: ['./urgent-procurement.component.css']
})
export class UrgentProcurementComponent implements OnInit {
  pharmacies: Pharmacy[] = [];
  filteredString: string = '';
  medicineName: string = '';
  medicineAmount: string = '';
  status: boolean = false;
  constructor(private pharmacyService: PharmacyService, private dialog: MatDialog, private urgentProcurementService: UrgentProcurementService) { }

  ngOnInit(): void {
    this.pharmacyService.getPharmacies().subscribe((pharmacies) => {this.pharmacies = pharmacies; console.log(JSON.stringify(this.pharmacies))});
  }

  check(pharmacyId: string) {
    this.urgentProcurementService.checkMedicine(this.medicineName, this.medicineAmount).subscribe((status) => 
    {
      this.status = status; 
      if (this.status) 
      {
        this.openDialog();
      } 
      else 
      {
        alert("Does not exist.")
      }
    });
  }

  orderMedicine(pharmacyId: string) {
    if (this.medicineName.trim() == '') {
      alert('Molimo unesite naziv leka.')
      return;
    }
    if (this.medicineAmount.trim() == '') {
      alert('Molimo unesite kolicinu leka.')
      return;
    }
    if (isNaN(Number(this.medicineAmount))) {
      alert('Molimo unesite validan broj za kolicinu leka.')
      return;
    }

    let medicine = new Medicine(this.medicineName, Number(this.medicineAmount));
    this.urgentProcurementService.orderGrpc(medicine).subscribe(
      (data) => {
        alert(data);
      }
    )

  }

  openDialog() {
    const dialogConfig = new MatDialogConfig();

        dialogConfig.disableClose = true;
        dialogConfig.autoFocus = true;

        const dialogRef = this.dialog.open(OrderDialogComponent, dialogConfig);

        dialogRef.afterClosed().subscribe(shouldOrder => this.order(shouldOrder));
        
  }

  order(shouldOrder: boolean) {
    if(!shouldOrder) {
      return;
    }
    this.urgentProcurementService.order(this.medicineName, this.medicineAmount);
  }

}
