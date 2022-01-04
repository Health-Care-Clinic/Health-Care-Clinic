import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IDoctor } from 'src/app/model/patient/doctor';
import { DoctorsService } from 'src/app/services/doctors.service';
import { ShiftsService } from 'src/app/services/shifts.service';
import { Shift } from 'src/app/model/shift';

@Component({
  selector: 'app-doctors',
  templateUrl: './doctors.component.html',
  styleUrls: ['./doctors.component.css']
})
export class DoctorsComponent implements OnInit {

  constructor(private doctorService: DoctorsService,private _route: ActivatedRoute,private router: Router, private shiftService: ShiftsService) { }

  doctors: Array<IDoctor>;
  shifts: Array<Shift>;

  ngOnInit(): void {
    this.doctorService.getAllDoctors().subscribe(ret =>{
      this.doctors = ret;
    })
    this.shiftService.getAllShifts().subscribe(ret => {
      this.shifts = ret;
      
      
    });
  }

  returnShift(idShift: number): string {
    for(let shift of this.shifts) {
      if(shift.id == idShift) {
        let sTime = shift.startTime.toString().split('T')[1];
        let eTime = shift.endTime.toString().split('T')[1];
        return (sTime + ' - ' + eTime);
      }
        
    }
      return ''
  }



}
