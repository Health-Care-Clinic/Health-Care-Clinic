import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { TypeOfBuilding } from 'src/app/model/building';
import { Room, TypeOfRoom } from 'src/app/model/room';
import { HospitalMapService } from 'src/app/services/hospital-map-service.service';


@Component({
  selector: 'app-floor',
  templateUrl: './floor.component.html',
  styleUrls: ['./floor.component.css']
})
export class FloorComponent implements OnInit {

  building: any;
  buildings: any;
  floor: any;
  idfString: string
  navigationSubscription;
  selectedBuilding: number;
  selectedFloor: any;
  selectedRoom: any;
  wcSelected: any;
  changeSelected: any;

  constructor(private _route: ActivatedRoute, private hospitalMapService: HospitalMapService, private router: Router) {
    this.navigationSubscription = this.router.events.subscribe((e: any) => {
      if (e instanceof NavigationEnd) {
        this.initialiseClass();
      }
    });
  }

  ngOnInit(): void {
    this.buildings = this.hospitalMapService.getBuildings();
    let idb = +this._route.snapshot.paramMap.get('idb');
    this.building = this.buildings.find(i => i.id === idb);
    this.idfString = this._route.snapshot.paramMap.get('idf');
    let idf = +this.idfString;
    this.floor = this.building.floors.find(i => i.id === idf);
  }

  initialiseClass(): void {
    this.buildings = this.hospitalMapService.getBuildings();
    let idb = +this._route.snapshot.paramMap.get('idb');
    this.building = this.buildings.find(i => i.id === idb);
    this.idfString = this._route.snapshot.paramMap.get('idf');
    let idf = +this.idfString;
    this.floor = this.building.floors.find(i => i.id === idf);
  }

  ngOnDestroy() {
    if (this.navigationSubscription) {
      this.navigationSubscription.unsubscribe();
    }
  }

  select(index: number) {
    var building = this.buildings.find(i => i.id === index);
    this.building = building;
    var buildingHTML = document.getElementById(index.toString());
    var nameHTML = <HTMLInputElement>document.getElementById("nameHTML");
    console.log(nameHTML);
   
    for (let i of this.buildings){
      if(i.id!==index){
        var unselectBuildingHTML = document.getElementById(i.id.toString());
        if ( unselectBuildingHTML!.style["fill"]=="rgb(193, 73, 83)" && i.type === TypeOfBuilding.Hospital) {
          unselectBuildingHTML!.style["fill"] = "url(#green)";
          
        }
      }
    }

    if ( buildingHTML!.style["fill"]=="rgb(193, 73, 83)") {

        buildingHTML!.style["fill"] = "url(#green)";
        
        nameHTML!.value = " ";
        this.selectedBuilding = null;
    }
    else {
        buildingHTML!.style["fill"] = "#C14953";   
        nameHTML!.value = building.name;
        this.selectedBuilding = index;
    }

  }

  public selectFloor(index: number){
    this.selectedFloor = this.floor;
    this.selectedRoom = null;
    this.wcSelected = null;
  }

  public selectRoom(index: number){
    var selectedRoomHTML = document.getElementById(index.toString());
    this.changeSelected = false;

    for (let room of this.floor.rooms){
      if(room.roomNumber === index){
        this.selectedRoom = room;
        if (room.type === TypeOfRoom.WC) {
          this.wcSelected = true;
        } else {
          this.wcSelected = false;
        }
        selectedRoomHTML.style["fill"] = "rgb(193, 73, 83)";
      } else {
        var unselectedRoomHTML = document.getElementById(room.roomNumber.toString());
        unselectedRoomHTML.style["fill"] = "#52DEE5";
      }
    }

  }

  public changeRoom(){
    this.changeSelected = true;
  }

  public editRoom(){
    this.changeSelected = false;

    var roomNameHTML: any;
    roomNameHTML = document.getElementById("roomNameHTML");
    var roomDescriptionHTML: any;
    roomDescriptionHTML = document.getElementById("roomDescriptionHTML");
    var roomDoctorHTML: any;
    roomDoctorHTML = document.getElementById("roomDoctorHTML");
    var roomWorkHourHTML: any;
    roomWorkHourHTML = document.getElementById("roomWorkHourHTML");

    this.selectedRoom.name = roomNameHTML.value;
    this.selectedRoom.description = roomDescriptionHTML.value;
    this.selectedRoom.doctor = roomDoctorHTML.value;
    this.selectedRoom.workHour = roomWorkHourHTML.value;
  }

}
