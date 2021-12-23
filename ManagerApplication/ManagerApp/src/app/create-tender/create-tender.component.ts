import { Component, OnInit } from '@angular/core';
import { Medicine } from '../model/medicine';

@Component({
  selector: 'app-create-tender',
  templateUrl: './create-tender.component.html',
  styleUrls: ['./create-tender.component.css']
})
export class CreateTenderComponent implements OnInit {

  public medicines: Medicine[] = [];
  public newMedicine: string = "";
  public newQuantity: number = null;

  constructor() { 
    //this.medicines = [{"name": "brufen", "quantity": 500}, {"name": "aspirin", "quantity": 800}];
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

}
