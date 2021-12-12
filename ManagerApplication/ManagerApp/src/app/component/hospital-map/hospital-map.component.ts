import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Building, TypeOfBuilding } from 'src/app/model/building';
import { Equipment } from 'src/app/model/equipment';
import { Floor } from 'src/app/model/floor';
import { Room } from 'src/app/model/room';
import { HospitalMapService } from 'src/app/services/hospital-map-service.service';

@Component({
  selector: 'app-hospital-map',
  templateUrl: './hospital-map.component.html',
  styleUrls: ['./hospital-map.component.css']
})
export class HospitalMapComponent implements OnInit {

  buildings : any;
  building: any;
  floors: any;
  selectedBuilding: any;
  searchedBuildings: any;
  searchedRooms: any;
  isHospital: boolean = false;
  equipments: any;
  equipmentsRooms: any;
  equipmentsFloors: any;
  equipmentsBuilding: any;
  roomSearchText: string = '';

  constructor(private hospitalMapService: HospitalMapService,public router: Router) {
  }
  ngOnInit(): void {
    this.hospitalMapService.getBuildings().subscribe(buildingsFromBack => {
          this.buildings = buildingsFromBack;
          this.equipments = new Array<Equipment>();
      });
  }

  public change(){
    var nameHTML = <HTMLInputElement>document.getElementById("nameHTML");
    for(let building of this.buildings){
      if(building.id == this.selectedBuilding){
        building.name=nameHTML!.value;
        this.hospitalMapService.changeBuildingName(building).subscribe(() => {

        })
      }
    }
  }

  public searchBuildings(){
    var searchText = (<HTMLInputElement>document.getElementById("buildingSearchHTML")).value;
    this.hospitalMapService.getSearchedBuildings(searchText).subscribe(searchedBuildingsFromBack => {   
      this.searchedBuildings = searchedBuildingsFromBack;
    })
  }

  public selectSearchedBuilding(index: number){
    this.searchedBuildings.length = 0;
    (<HTMLInputElement>document.getElementById("buildingSearchHTML")).value = "";
    this.select(index);
  }

  public setRoomSearchText(){
    this.roomSearchText = (<HTMLInputElement>document.getElementById("roomSearchHTML")).value;
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
        this.building = null;
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

    this.hospitalMapService.getFloorsByBuildingId(this.selectedBuilding).subscribe(floorsFromBack => {   
      this.floors = floorsFromBack;
    })
  }

  public findEquipment(){
    var equipmentHTML = <HTMLInputElement>document.getElementById("equipmentHTML");
    this.hospitalMapService.getEquipmentByName(equipmentHTML.value).subscribe(equipmentFromBack=>{
      this.equipments = equipmentFromBack;
      this.equipmentsRooms = new Array<Room>(this.equipments?.length);
      this.equipmentsFloors = new Array<Floor>(this.equipments?.length);
      this.equipmentsBuilding = new Array<Building>(this.equipments?.length);
      for(let i=0;i<this.equipments.length;i++){
        this.hospitalMapService.getRoomById(this.equipments[i].roomId).subscribe(roomFromBack =>{
          this.equipmentsRooms[i] = roomFromBack;
          this.hospitalMapService.getFloorById(roomFromBack.floorId).subscribe(floorFromBack=>{
            this.equipmentsFloors[i] = floorFromBack;
            this.hospitalMapService.getBuildingById(floorFromBack.buildingId).subscribe(buildingFromBack =>{
              this.equipmentsBuilding[i] = buildingFromBack;
              
            
          })
          
        })
      })
      }
      

    })
  }
  
  public goToRoom(roomId:number){
    this.hospitalMapService.getRoomById(roomId).subscribe(roomFromBack => {
      this.hospitalMapService.getFloorById(roomFromBack.floorId).subscribe(floorFromBack =>{
        this.hospitalMapService.getBuildingById(floorFromBack.buildingId).subscribe(buildingFromBack =>{
          this.router.navigate(['/floor', buildingFromBack.id, floorFromBack.id,roomFromBack.id]);
        })
      })
    })
    
  }
}





