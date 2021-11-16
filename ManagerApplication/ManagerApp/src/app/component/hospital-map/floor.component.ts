import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { TypeOfBuilding } from 'src/app/model/building';
import { Floor } from 'src/app/model/floor';
import { Room, TypeOfRoom } from 'src/app/model/room';
import { HospitalMapService } from 'src/app/services/hospital-map-service.service';


@Component({
  selector: 'app-floor',
  templateUrl: './floor.component.html',
  styleUrls: ['./floor.component.css']
})
export class FloorComponent implements OnInit {

  building: any;
  floors: any;
  floor: any;
  idfString: string
  navigationSubscription;
  selectedBuilding: number;
  selectedFloor: any;
  selectedRoom: any;
  wcSelected: any;
  changeSelected: any;
  rooms: any;

  constructor(private _route: ActivatedRoute, private hospitalMapService: HospitalMapService, private router: Router) {
    this.navigationSubscription = this.router.events.subscribe((e: any) => {
      if (e instanceof NavigationEnd) {
        this.initialiseClass();
      }
    });
  }

  ngOnInit(): void {
    let idb = +this._route.snapshot.paramMap.get('idb');
    this.hospitalMapService.getBuildingById(idb).subscribe(buildingFromBack => {
      this.building = buildingFromBack
      this.idfString = this._route.snapshot.paramMap.get('idf');
      let idf = +this.idfString;
      this.hospitalMapService.getFloorsByBuildingId(this.building.id).subscribe(floorsFromBack => {
          this.floors = floorsFromBack ;
          for (let floor of this.floors){
            if(idf == floor.id){
              this.floor = floor;
              this.hospitalMapService.getRoomsByFloorId(this.floor.id).subscribe(roomsFromBack =>{
                this.rooms = roomsFromBack;
              });
            }
          }
        }
      )
  });
  }

  initialiseClass(): void {
    let idb = +this._route.snapshot.paramMap.get('idb');
    this.hospitalMapService.getBuildingById(idb).subscribe(buildingFromBack => {
      this.building = buildingFromBack
      this.idfString = this._route.snapshot.paramMap.get('idf');
      let idf = +this.idfString;
      this.hospitalMapService.getFloorsByBuildingId(this.building.id).subscribe(floorsFromBack => {
          this.floors = floorsFromBack ;
          for (let floor of this.floors){
            if(idf == floor.id){
              this.floor = floor;
              this.hospitalMapService.getRoomsByFloorId(this.floor.id).subscribe(roomsFromBack =>{
                this.rooms = roomsFromBack;
              });
            }
          }
        }
      )
  });
  }

  ngOnDestroy() {
    if (this.navigationSubscription) {
      this.navigationSubscription.unsubscribe();
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
      for (let room of this.rooms){
        if(room.id == index){
            this.selectedRoom = room;
            if (room.type === TypeOfRoom.WC) {
              this.wcSelected = true;
            } 
            else 
            {
              this.wcSelected = false;
            }
            selectedRoomHTML.style["fill"] = "rgb(193, 73, 83)";
            } 
            else {
            
            var unselectedRoomHTML = document.getElementById(room.id.toString());
            if (unselectedRoomHTML!= null){
            unselectedRoomHTML.style["fill"] = "#52DEE5";
            }
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
    for (let room of this.rooms){
      if(room.id == this.selectedRoom){
        room.name = roomNameHTML.value;
        room.description = roomDescriptionHTML.value;
      }
    }
    this.selectedRoom.name = roomNameHTML.value;
    this.selectedRoom.description = roomDescriptionHTML.value;

 
  }

}
