import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IDoctor } from 'src/app/model/patient/doctor';
import { Vacation } from 'src/app/model/vacation';
import { DoctorsService } from 'src/app/services/doctors.service';
import { VacationService } from 'src/app/services/vacation.service';

@Component({
  selector: 'app-doctor-vacations',
  templateUrl: './doctor-vacations.component.html',
  styleUrls: ['./doctor-vacations.component.css']
})
export class DoctorVacationsComponent implements OnInit {
  
  doctor: IDoctor;
  vacations: Array<Vacation>;
  pastVacations: Array<Vacation>;
  currentVacations: Array<Vacation>;
  futureVacations: Array<Vacation>;

  constructor(private _route: ActivatedRoute, private vacationService: VacationService, private doctorService: DoctorsService) { }

  ngOnInit(): void {
    var doctorId = +this._route.snapshot.paramMap.get('iddv');
    this.doctorService.getAllDoctors().subscribe(ret => {
      for (let d of ret) {
        if (d.id == doctorId) {
          this.doctor = d;
        }
      }
    });
    this.vacationService.getAllDoctorVacations(doctorId).subscribe(ret => {
      this.vacations = ret;
    });
    this.vacationService.getPastDoctorVacations(doctorId).subscribe(ret => {
      this.pastVacations = ret;
    });
    this.vacationService.getCurrentDoctorVacations(doctorId).subscribe(ret => {
      this.currentVacations = ret;
    });
    this.vacationService.getFutureDoctorVacations(doctorId).subscribe(ret => {
      this.futureVacations = ret;
    });
  }

}
