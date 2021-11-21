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
    let next2 = document.getElementById('next2') as HTMLButtonElement;
    next2.disabled = true;
    let back1 = document.getElementById('back1') as HTMLButtonElement;
    back1.disabled = true;
    let select2 = document.getElementById('select2') as HTMLSelectElement;
    select2.disabled = true;
   }

  onSubmit() : void{
    let next1 = document.getElementById('next1') as HTMLButtonElement;
    next1.disabled = true;
    let select1 = document.getElementById('select1') as HTMLSelectElement;
    select1.disabled = true;
    
    let next2 = document.getElementById('next2') as HTMLButtonElement;
    next2.disabled = false;
    let back1 = document.getElementById('back1') as HTMLButtonElement;
    back1.disabled = false;
    let select2 = document.getElementById('select2') as HTMLSelectElement;
    select2.disabled = false;

    this.selectedEquipment = select1.value;

    let roomIds = []
    this.roomsWithEquipment = []
    for (let e of this.allEquipment) {
      if (e.name === this.selectedEquipment){
        roomIds.push(e.roomId)
        this.roomsWithEquipment.push(e)
      }
    }

    this.hospitalMapService.getRooms().subscribe(roomsFromBack =>{
      let allRooms = roomsFromBack;
    })
  }

  onSubmit2() : void {
    let next2 = document.getElementById('next2') as HTMLButtonElement;
    next2.disabled = true;
    let back1 = document.getElementById('back1') as HTMLButtonElement;
    back1.disabled = true;
    let select2 = document.getElementById('select2') as HTMLSelectElement;
    select2.disabled = true;

    this.selectedRoom = select2.value;
  }

  back1() : void {
    let next1 = document.getElementById('next1') as HTMLButtonElement;
    next1.disabled = false;
    let select1 = document.getElementById('select1') as HTMLSelectElement;
    select1.disabled = false;
  }

}
