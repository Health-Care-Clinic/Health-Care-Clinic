import { Component, OnInit } from '@angular/core';
import { ShiftsService } from 'src/app/services/shifts.service';
import { ActivatedRoute, Router } from '@angular/router';
import { DoctorsService } from 'src/app/services/doctors.service';
import { IDoctor } from 'src/app/model/patient/doctor';

@Component({
  selector: 'app-adding-shift',
  templateUrl: './adding-shift.component.html',
  styleUrls: ['./adding-shift.component.css']
})
export class AddingShiftComponent implements OnInit {

  radioInput: any;
  allDoctors: Array<IDoctor>;
  errorMessage: Boolean;

  constructor(private _route: ActivatedRoute, private router: Router, private doctorsService: DoctorsService) { }

  ngOnInit(): void {
    this.doctorsService.getAllDoctors().subscribe(ret => {
      this.allDoctors = ret;
    }) 

    this.errorMessage = false;
    this.radioInput = -1;
  }

  add(): void {
    if(this.radioInput == -1) {
      this.errorMessage = true;
      return;
    }
    this.errorMessage = false;

    var doctorId = + this._route.snapshot.paramMap.get('ida');
    for(let d of this.allDoctors) {
      if(d.id == doctorId) {
        this.doctorsService.addShift(d, parseInt(this.radioInput)).subscribe(() =>  {
          this.router.navigate(['/doctors']);
        })
      }
    }
  }
}
