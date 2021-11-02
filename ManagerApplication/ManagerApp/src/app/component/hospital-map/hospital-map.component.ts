import { Component, OnInit } from '@angular/core';
import { Building, TypeOfBuilding } from 'src/app/model/building';
import { HospitalMapService } from 'src/app/services/hospital-map-service.service';

@Component({
  selector: 'app-hospital-map',
  templateUrl: './hospital-map.component.html',
  styleUrls: ['./hospital-map.component.css']
})
export class HospitalMapComponent implements OnInit {

  buildings : any;
  building: any;
  selectedBuilding: any;
  isHospital: boolean = false;

  constructor(private hospitalMapService: HospitalMapService) {

  }

  ngOnInit(): void {
    this.buildings=this.hospitalMapService.getBuildings();
  }

  public change(){
    var nameHTML = <HTMLInputElement>document.getElementById("nameHTML");
    this.buildings.find(i => i.id === this.selectedBuilding).name=nameHTML!.value;


  }

  public select(index:number){
    var building = this.buildings.find(i => i.id === index);
    this.building = building;
    var buildingHTML = document.getElementById(index.toString());
    var nameHTML = <HTMLInputElement>document.getElementById("nameHTML");
    
   
    for (let i of this.buildings){
      if(i.id!==index){
        var unselectBuildingHTML = document.getElementById(i.id.toString());
        if ( unselectBuildingHTML!.style["fill"]=="rgb(193, 73, 83)" && i.type === TypeOfBuilding.Hospital) {
          unselectBuildingHTML!.style["fill"] = "url(#green)";
          
        }
        else if(unselectBuildingHTML!.style["fill"]=="rgb(193, 73, 83)" && i.type === TypeOfBuilding.Parking){
          unselectBuildingHTML!.style["fill"] = "url(#blue)";
        }
      }
    }
    


    if ( buildingHTML!.style["fill"]=="rgb(193, 73, 83)") {
        if(building.type === TypeOfBuilding.Hospital){
          buildingHTML!.style["fill"] = "url(#green)";
        }
        else if(building.type === TypeOfBuilding.Parking){
          buildingHTML!.style["fill"] = "url(#blue)";
        }
        nameHTML!.value = " ";
        this.selectedBuilding = null;
    }
    else {
        buildingHTML!.style["fill"] = "#C14953";   
        nameHTML!.value = building.name;
        this.selectedBuilding = index;
    }

    if(building.type === TypeOfBuilding.Hospital){
      this.isHospital = true;
    }
    else 
      this.isHospital = false;
  }
}





