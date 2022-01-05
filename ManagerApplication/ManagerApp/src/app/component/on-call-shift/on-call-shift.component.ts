import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { OnCallShift } from 'src/app/model/on-call-shift';
import { OnCallShiftService } from 'src/app/services/on-call-shift.service';

@Component({
  selector: 'app-on-call-shift',
  templateUrl: './on-call-shift.component.html',
  styleUrls: ['./on-call-shift.component.css']
})
export class OnCallShiftComponent implements OnInit {

  onCallShifts: Array<OnCallShift>
  OnCallShiftId: any;
  selectedOnCallShift: OnCallShift;

  constructor(private _route: ActivatedRoute,private onCallShiftService: OnCallShiftService ) { }

  ngOnInit(): void {
    this.OnCallShiftId = +this._route.snapshot.paramMap.get('ido');  
    this.onCallShiftService.getAllDoctorsOnCallShifts(this.OnCallShiftId).subscribe(ret => {
      this.onCallShifts = ret;
    })
  }

  append(id: number){
    for (let onCall of this.onCallShifts){
      if (onCall.id==id){
        this.selectedOnCallShift = onCall;
        var inputHTML = <HTMLInputElement>document.getElementById("inputId");
        inputHTML.value = this.selectedOnCallShift.date.toString().substr(0, 10);
        break;
      }
    }
  }

  change(){
    var inputHTML = <HTMLInputElement>document.getElementById("inputId");
    this.selectedOnCallShift.date = inputHTML.valueAsDate;
    this.onCallShiftService.changeOnCallShift(this.selectedOnCallShift).subscribe(ret => {
      alert("Date changed");
    })
  }

}
