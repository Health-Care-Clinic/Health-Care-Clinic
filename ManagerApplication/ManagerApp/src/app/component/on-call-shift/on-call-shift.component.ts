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

  constructor(private _route: ActivatedRoute,private onCallShiftService: OnCallShiftService ) { }

  ngOnInit(): void {
    this.OnCallShiftId = +this._route.snapshot.paramMap.get('ido');  
    this.onCallShiftService.getAllDoctorsOnCallShifts(this.OnCallShiftId).subscribe(ret => {
      this.onCallShifts = ret;
    })
  }

}
