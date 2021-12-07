import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HospitalMapService } from 'src/app/services/hospital-map-service.service';

@Component({
  selector: 'app-room-schedule',
  templateUrl: './room-schedule.component.html',
  styleUrls: ['./room-schedule.component.css']
})
export class RoomScheduleComponent implements OnInit {

  transfers: any;

  constructor(private _route: ActivatedRoute, private hospitalMapService: HospitalMapService) { }

  ngOnInit(): void {
    var roomId = +this._route.snapshot.paramMap.get('idr');  
    this.hospitalMapService.getRoomTransfers(roomId).subscribe(transfersFromBack=>{
      this.transfers = transfersFromBack;
    })
  }

}
