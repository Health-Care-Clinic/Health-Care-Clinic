import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { OnCallShift } from 'src/app/model/on-call-shift';
import { OnCallShiftService } from 'src/app/services/on-call-shift.service';

@Component({
  selector: 'app-new-on-call-shift',
  templateUrl: './new-on-call-shift.component.html',
  styleUrls: ['./new-on-call-shift.component.css']
})
export class NewOnCallShiftComponent implements OnInit {

  nextPressed: Boolean;
  freeDates: Array<Date>;
  radioInput: any = -1;
  errorMessage: Boolean;

  constructor(private _route: ActivatedRoute, private onCallShiftService: OnCallShiftService, private router: Router) { }

  ngOnInit(): void {
    this.nextPressed = false;
    this.errorMessage = false;
  }

  next(): void {
    let select = document.getElementById('select1') as HTMLSelectElement;
    select.disabled = true;
    let next = document.getElementById('next1') as HTMLButtonElement;
    next.disabled = true;
    this.nextPressed = true;

    this.onCallShiftService.getFreeDates(parseInt(select.value)).subscribe(ret => {
      this.freeDates = ret; 
    })
  }

  back(): void {
    let select = document.getElementById('select1') as HTMLSelectElement;
    select.disabled = false;
    let next = document.getElementById('next1') as HTMLButtonElement;
    next.disabled = false;
    this.nextPressed = false;
    this.radioInput = -1;
    this.errorMessage = false;
  }

  submit(): void {
    if(this.radioInput == -1) {
      this.errorMessage = true;
      return;
    }
    this.errorMessage = false;
    var OnCallShiftId = + this._route.snapshot.paramMap.get('ide');  
    let date = this.freeDates[this.radioInput]

    let onCallShift = new OnCallShift(0, OnCallShiftId, date);

    this.onCallShiftService.addOnCallShift(onCallShift).subscribe(() =>  {
      this.router.navigate(['/doctors']);
    })
  }

}
