import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Medicine } from '../model/medicine';
import { ITenderDTO } from '../dto/TenderDTO';
import { TenderingServiceService } from '../services/tendering-service.service';

@Component({
  selector: 'app-create-tender',
  templateUrl: './create-tender.component.html',
  styleUrls: ['./create-tender.component.css'],
  providers: [ TenderingServiceService, DatePipe ]
})
export class CreateTenderComponent implements OnInit {

  public medicines: Medicine[] = [];
  public newMedicine: string = "";
  public newQuantity: number = null;
  public startDate = new Date();
  public endDate = new Date();
  public description: string = "";
  public tender: ITenderDTO = { id: 0, startDate: "", endDate: "", description: "", isWinningBidChosen: false, price: null, medicines: null, isOpen: true, offersNumber: 0 }

  constructor(private _tenderingService : TenderingServiceService, public datepipe: DatePipe) { 
    this.tender;
  }

  ngOnInit(): void {
  }

  addMedicine(): void {
    if (this.newMedicine != "" && this.newQuantity > 0) {
      let medicine = {"name": this.newMedicine, "quantity": this.newQuantity}
      this.medicines.push(medicine);
      this.newMedicine = "";
      this.newQuantity = null;
    }
  }

  createTender(): void {
    this.tender.startDate = this.datepipe.transform(this.startDate, 'yyyy-MM-dd');
    this.tender.endDate = this.datepipe.transform(this.endDate, 'yyyy-MM-dd');
    this.tender.description = this.description;
    this.tender.isOpen = true;
    this.tender.isWinningBidChosen = false;
    this.tender.price = 0;
    this.tender.medicines = this.medicines;
    this.tender.offersNumber = 0;
    console.log(this.tender)
    this._tenderingService.createTender(this.tender).subscribe();
  }

}
