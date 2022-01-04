import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Shift } from 'src/app/model/shift';
import { ShiftsService } from 'src/app/services/shifts.service';

@Component({
  selector: 'app-add-shift',
  templateUrl: './add-shift.component.html',
  styleUrls: ['./add-shift.component.css']
})
export class AddShiftComponent implements OnInit {

  shiftName: string;
  stringShiftStartTime: any;
  stringShiftEndTime: any;
  shiftStartTime: any;
  shiftEndTime: any;
  errorRequired: boolean = false;
  error: boolean = false;

  constructor(private shiftsService: ShiftsService, private _router: Router) { }

  ngOnInit(): void {
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
    
    this.shiftsService.getAllShifts().subscribe(shifts => {
      let newId = 0;
      for (let shift of shifts) {
        if (shift.id > newId) {
          newId = shift.id;
        }
      }

      let shift = new Shift(newId + 1, this.shiftName, this.shiftStartTime, this.shiftEndTime);
      this.shiftsService.addShift(shift).subscribe(shiftAdded =>{
        if(!shiftAdded)
          this.error = true;
        else
          this._router.navigate(["shifts"])
      })
    })
  }
}
