import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Pharmacy } from 'src/app/dto/Pharmacy';
import { PharmacyService } from 'src/app/services/pharmacy.service';
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
  constructor(private pharmacyService: PharmacyService, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.pharmacyService.getPharmacies().subscribe((pharmacies) => {this.pharmacies = pharmacies; console.log(JSON.stringify(this.pharmacies))});
  }

  check(pharmacyId: string) {
    if (true) {
      this.openDialog();
    }
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
    alert("ORDERING");
  }

}
