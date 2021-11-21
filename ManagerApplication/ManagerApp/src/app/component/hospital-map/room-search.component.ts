import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Building } from 'src/app/model/building';
import { Floor } from 'src/app/model/floor';
import { HospitalMapService } from 'src/app/services/hospital-map-service.service';

@Component({
  selector: 'app-room-search',
  templateUrl: './room-search.component.html',
  styleUrls: ['./room-search.component.css']
})
export class RoomSearchComponent implements OnInit {

  rooms: any;
  roomsFloors: any;
  roomsBuildings: any;

  constructor(private _route: ActivatedRoute, private hospitalMapService: HospitalMapService, public router: Router) { }

  ngOnInit(): void {
    var searchText = this._route.snapshot.paramMap.get('searchText');  
    this.hospitalMapService.getSearchedRooms(searchText).subscribe(roomsFromBack=>{
      this.rooms = roomsFromBack;
      this.roomsFloors = new Array<Floor>(this.rooms?.length);
      this.roomsBuildings = new Array<Building>(this.rooms?.length);
      for(let i=0;i<this.rooms.length;i++){
        this.hospitalMapService.getFloorById(this.rooms[i].floorId).subscribe(floorFromBack =>{
          this.roomsFloors[i] = floorFromBack;
          this.hospitalMapService.getBuildingById(floorFromBack.buildingId).subscribe(buildingFromBack=>{
            this.roomsBuildings[i] = buildingFromBack;
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
