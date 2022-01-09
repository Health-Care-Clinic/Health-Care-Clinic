import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DoctorsService } from 'src/app/services/doctors.service';
import { IDoctor } from 'src/app/model/patient/doctor';

@Component({
  selector: 'app-edit-doctor-shift',
  templateUrl: './edit-doctor-shift.component.html',
  styleUrls: ['./edit-doctor-shift.component.css']
})
export class EditDoctorShiftComponent implements OnInit {

  radioInput: any = -1;
  allDoctors: Array<IDoctor>;
  errorMessage: Boolean;

  constructor(private _route: ActivatedRoute, private router: Router, private doctorsService: DoctorsService) { }

  ngOnInit(): void {
    var doctorId = + this._route.snapshot.paramMap.get('idu');
    this.doctorsService.getAllDoctors().subscribe(ret => {
      this.allDoctors = ret;

      this.errorMessage = false;
    }) 
    
  }

  edit(): void {
    if(this.radioInput == -1) {
      this.errorMessage = true;
      return;
    }

    this.errorMessage = false;
    var doctorId = + this._route.snapshot.paramMap.get('idu');

    for(let d of this.allDoctors) {
      if(d.id == doctorId) {
        this.doctorsService.addShift(d, parseInt(this.radioInput)).subscribe(() =>  {
          this.router.navigate(['/doctors']);
        })
      }
    }
  }

}
