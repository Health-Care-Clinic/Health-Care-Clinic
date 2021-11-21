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

  ngOnInit(): void { }

  onSubmit() : void{
    let next1 = document.getElementById('next1');
    next1.setAttribute('disabled', 'true');
    let select1 = document.getElementById('select1') as HTMLSelectElement;
    select1.setAttribute('disabled', 'true');
    this.selectedEquipment = select1.value;
  }

}
