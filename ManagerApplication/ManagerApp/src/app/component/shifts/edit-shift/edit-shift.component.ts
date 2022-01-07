import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Shift } from 'src/app/model/shift';
import { ShiftsService } from 'src/app/services/shifts.service';

@Component({
  selector: 'app-edit-shift',
  templateUrl: './edit-shift.component.html',
  styleUrls: ['./edit-shift.component.css']
})
export class EditShiftComponent implements OnInit {

  shiftName: string;
  stringShiftStartTime: any;
  stringShiftEndTime: any;
  shiftStartTime: any;
  shiftEndTime: any;
  errorRequired: boolean = false;
  error: boolean = false;
  ids: any;

  constructor(private shiftsService: ShiftsService, private _router: Router, private _route: ActivatedRoute) { }

  ngOnInit(): void {
    this.ids = +this._route.snapshot.paramMap.get('ids');
    this.shiftsService.getShiftById(this.ids).subscribe(shift => {
      this.shiftName = shift.name;
      this.stringShiftStartTime = (new Date(shift.startTime).getHours()<10?'0':'') + (new Date(shift.startTime)).getHours() + ":" + (new Date(shift.startTime).getMinutes()<10?'0':'') + (new Date(shift.startTime)).getMinutes();
      this.stringShiftEndTime = (new Date(shift.endTime).getHours()<10?'0':'') + (new Date(shift.endTime)).getHours() + ":" + (new Date(shift.endTime).getMinutes()<10?'0':'') + (new Date(shift.endTime)).getMinutes();
    })
  }

  setStartAndEndTime(): void{
    let hoursShiftStartTime = Number(this.stringShiftStartTime.split(":", 2)[0]);
    let minutesShiftStartTime = Number(this.stringShiftStartTime.split(":", 2)[1]);
    let hoursShiftEndTime = Number(this.stringShiftEndTime.split(":", 2)[0]);
    let minutesShiftEndTime = Number(this.stringShiftEndTime.split(":", 2)[1]);
    this.shiftStartTime = new Date();
    this.shiftStartTime.setHours(hoursShiftStartTime + 1);
    this.shiftStartTime.setMinutes(minutesShiftStartTime);
    this.shiftStartTime.setSeconds(0);
    this.shiftStartTime.setMilliseconds(0);
    this.shiftEndTime = new Date();
    this.shiftEndTime.setHours(hoursShiftEndTime + 1);
    this.shiftEndTime.setMinutes(minutesShiftEndTime);
    this.shiftEndTime.setSeconds(0);
    this.shiftEndTime.setMilliseconds(0);
  }

  onSubmit(): void{
    this.errorRequired = false;
    this.error = false;

    if(!this.shiftName || !this.stringShiftStartTime || !this.stringShiftEndTime){
      this.errorRequired = true;
      return;
    }

    this.setStartAndEndTime();
    
    let shift = new Shift(this.ids, this.shiftName, this.shiftStartTime, this.shiftEndTime);
    this.shiftsService.editShift(shift).subscribe(shiftEdited =>{
      if(!shiftEdited)
        this.error = true;
      else
        this._router.navigate(["shifts"])
    })
  }
}
