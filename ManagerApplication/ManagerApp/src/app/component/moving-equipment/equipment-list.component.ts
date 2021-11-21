import { Component, OnInit } from '@angular/core';
import { HospitalMapService } from 'src/app/services/hospital-map-service.service';

@Component({
  selector: 'app-equipment-list',
  templateUrl: './equipment-list.component.html',
  styleUrls: ['./equipment-list.component.css']
})
export class EquipmentListComponent implements OnInit {

  allEquipment: any;
  equipmentNames: any;
  selectedEquipment: any;
  roomsWithEquipment: any;
  selectedRoom: any;
  maxQuantity: any;
  selectedQuantity: any;

  backButton1: any;
  backButton2: any;
  backButton3: any;

  constructor(private hospitalMapService: HospitalMapService) {
    this.hospitalMapService.getAllEquipment().subscribe(equipmentFromBack =>{
      this.allEquipment = equipmentFromBack;
      this.equipmentNames = []
      for (let e of this.allEquipment) {
        if (!this.equipmentNames.includes(e.name)){
          this.equipmentNames.push(e.name)
        }
      }
    })
   }

  ngOnInit(): void {
    this.step2Disable();
    this.step3Disable();

    this.backButton1 = false;
    this.backButton2 = false;
    this.backButton3 = false;
   }

  onSubmit() : void{
    this.step1Disable();
    this.step2Enable();

    this.roomsWithEquipment = []
    for (let e of this.allEquipment) {
      if (e.name === this.selectedEquipment){
        this.roomsWithEquipment.push(e)
      }
    }
  }

  onSubmit2() : void {
    if (this.backButton1) {
      this.step1Enable();
      this.step3Disable();
    } else {
      this.step3Enable();
    }

    this.step2Disable();

    this.backButton1 = false;

    this.maxQuantity = 1;
    for (let e of this.allEquipment) {
      if (e.roomId == this.selectedRoom){
        this.maxQuantity = e.quantity;
        break;
      }
    }

  }

  back1() : void {
    this.backButton1 = true;
  }

  onSubmit3() : void {
    let next3 = document.getElementById('next3') as HTMLButtonElement;
    next3.disabled = true;
    let back2 = document.getElementById('back2') as HTMLButtonElement;
    back2.disabled = true;
    let select3 = document.getElementById('select3') as HTMLSelectElement;
    select3.disabled = true;

    this.selectedQuantity = select3.value;
  }

  back2() : void {
    let next2 = document.getElementById('next2') as HTMLButtonElement;
    next2.disabled = false;
    let back1 = document.getElementById('back1') as HTMLButtonElement;
    back1.disabled = false;
    let select2 = document.getElementById('select2') as HTMLSelectElement;
    select2.disabled = false;
  }

  step1Enable() : void {
    let next1 = document.getElementById('next1') as HTMLButtonElement;
    next1.disabled = false;
    let select1 = document.getElementById('select1') as HTMLSelectElement;
    select1.disabled = false;
  }

  step1Disable() : void {
    let next1 = document.getElementById('next1') as HTMLButtonElement;
    next1.disabled = true;
    let select1 = document.getElementById('select1') as HTMLSelectElement;
    select1.disabled = true;

    this.selectedEquipment = select1.value;
  }

  step2Enable() : void {
    let next2 = document.getElementById('next2') as HTMLButtonElement;
    next2.disabled = false;
    let back1 = document.getElementById('back1') as HTMLButtonElement;
    back1.disabled = false;
    let select2 = document.getElementById('select2') as HTMLSelectElement;
    select2.disabled = false;
  }

  step2Disable() : void {
    let next2 = document.getElementById('next2') as HTMLButtonElement;
    next2.disabled = true;
    let back1 = document.getElementById('back1') as HTMLButtonElement;
    back1.disabled = true;
    let select2 = document.getElementById('select2') as HTMLSelectElement;
    select2.disabled = true;

    this.selectedRoom = select2.value;
  }

  step3Enable() : void {
    let next3 = document.getElementById('next3') as HTMLButtonElement;
    next3.disabled = false;
    let back2 = document.getElementById('back2') as HTMLButtonElement;
    back2.disabled = false;
    let select3 = document.getElementById('select3') as HTMLSelectElement;
    select3.disabled = false;
  }

  step3Disable() : void {
    let next3 = document.getElementById('next3') as HTMLButtonElement;
    next3.disabled = true;
    let back2 = document.getElementById('back2') as HTMLButtonElement;
    back2.disabled = true;
    let select3 = document.getElementById('select3') as HTMLSelectElement;
    select3.disabled = true;
  }

}
