import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IDoctor } from 'src/app/model/patient/doctor';
import { Vacation } from 'src/app/model/vacation';
import { DoctorsService } from 'src/app/services/doctors.service';
import { VacationService } from 'src/app/services/vacation.service';

@Component({
  selector: 'app-delete-doctor-vacation',
  templateUrl: './delete-doctor-vacation.component.html',
  styleUrls: ['./delete-doctor-vacation.component.css']
})
export class DeleteDoctorVacationComponent implements OnInit {

  vacation: Vacation;
  doctor: IDoctor;
  found: boolean;

  constructor(private _route: ActivatedRoute, private vacationService: VacationService, private doctorService: DoctorsService) { }

  ngOnInit(): void {
    this.found = false;
    
    var vacationId = +this._route.snapshot.paramMap.get('idvd');
    this.vacationService.getAllVacations().subscribe(ret => {
      for (let v of ret) {
        if (v.id == vacationId) {
          this.vacation = v;
          this.doctorService.findById(v.doctorId).subscribe(ret => {
            this.doctor = ret;
          });
          this.found = true;
          break;
        }
      }
    });
  }

  deleteVacation(): void {
    this.vacationService.deleteVacation(this.vacation).subscribe(ret => {
      
    });
  }

}
