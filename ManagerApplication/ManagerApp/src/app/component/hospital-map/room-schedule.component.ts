import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { Transfer } from 'src/app/model/transfer';
import { HospitalMapService } from 'src/app/services/hospital-map-service.service';

@Component({
  selector: 'app-room-schedule',
  templateUrl: './room-schedule.component.html',
  styleUrls: ['./room-schedule.component.css']
})
export class RoomScheduleComponent implements OnInit {

  transfers: any;
  transfersCancellable: Boolean[] = [];
  renovationsCancellable: Boolean[] = [];
  renovations: any;
  appointments: any;
  selectedOption: string = 'Transfers';

  constructor(private _route: ActivatedRoute, private hospitalMapService: HospitalMapService) { }

  ngOnInit(): void {
    var roomId = +this._route.snapshot.paramMap.get('idr');  
    this.hospitalMapService.getRoomTransfers(roomId).subscribe(transfersFromBack=>{
      this.transfers = transfersFromBack;
      this.transfersCancellable = new Array<Boolean>(this.transfers?.length);
      for(let i=0; i < this.transfers.length; i++)
      {
        this.hospitalMapService.checkIfTransferCancellable(this.transfers[i].id).subscribe(isCancellable=>{
          this.transfersCancellable[i] = isCancellable;
        })
      }
    })

    this.hospitalMapService.getRoomRenovations(roomId).subscribe(renovationsFromBack=>{
      this.renovations = renovationsFromBack;
      this.renovationsCancellable = new Array<Boolean>(this.renovations?.length);
      for(let i=0; i < this.renovations.length; i++)
      {
        this.hospitalMapService.checkIfRenovationCancellable(this.renovations[i].id).subscribe(isCancellable=>{
          this.renovationsCancellable[i] = isCancellable;
        })
      }
    })

    this.hospitalMapService.getRoomAppointments(roomId).subscribe(appointmentsFromBack=>{
      this.appointments = appointmentsFromBack;
    })
  }

  public cancelTransfer(transferId:number){
    for(let i = 0; i < this.transfers.length; ++i){
      if (this.transfers[i].id === transferId) {
          this.hospitalMapService.deleteCancelledTransfer(this.transfers[i]).subscribe(() =>  {});
          this.transfers.splice(i,1);
          this.transfersCancellable.splice(i,1);
          break;
      }
    } 
  }

  public OnOptionSelected(event: any){
    this.selectedOption = event.target.value;
  }

  public cancelRenovation(renovationId:number){
    for(let i = 0; i < this.renovations.length; ++i){
      if (this.renovations[i].id === renovationId) {
          this.hospitalMapService.deleteCancelledRenovation(this.renovations[i]).subscribe(() =>  {});
          this.renovations.splice(i,1);
          this.renovationsCancellable.splice(i,1);
          break;
      }
    } 
  }

}
