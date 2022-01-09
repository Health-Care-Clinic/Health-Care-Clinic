import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IDoctor } from 'src/app/model/patient/doctor';
import { Vacation } from 'src/app/model/vacation';
import { VacationService } from 'src/app/services/vacation.service';
import { DoctorsService } from 'src/app/services/doctors.service';

@Component({
  selector: 'app-schedule-doctor-vacation',
  templateUrl: './schedule-doctor-vacation.component.html',
  styleUrls: ['./schedule-doctor-vacation.component.css']
})
export class ScheduleDoctorVacationComponent implements OnInit {

  doctor: IDoctor;
  startTime: Date;
  endTime: Date;
  description: string;
  doctorVacations: Array<Vacation>;
  vacations: Array<Vacation>;
  today: string;
  found: boolean;

  constructor(private _route: ActivatedRoute, private vacationService: VacationService, private doctorService: DoctorsService) { }

  ngOnInit(): void {
    this.found = false;

    var doctorId = +this._route.snapshot.paramMap.get('iddc');
    this.doctorService.getAllDoctors().subscribe(ret => {
      for (let d of ret) {
        if (d.id == doctorId) {
          this.doctor = d;
          this.found = true;
          break;
        }
      }
    });

    this.vacationService.getAllDoctorVacations(doctorId).subscribe(ret => {
      this.doctorVacations = ret;
    });

    this.vacationService.getAllVacations().subscribe(ret => {
      this.vacations = ret;
    });

    this.today = this.getTodayStringDate();
  }

  onSubmit() : void {
    let startDate = document.getElementById('startDate') as HTMLInputElement;
    let endDate = document.getElementById('endDate') as HTMLInputElement;
    let descriptionInput = document.getElementById('description') as HTMLInputElement;

    if (startDate.valueAsDate < new Date()) {
      alert('Start date should be later than today!');
    }
    else if (endDate.valueAsDate < new Date()) {
      alert('End date should be later than today!');
    }
    else if (endDate.valueAsDate < startDate.valueAsDate) {
      alert('End date should be later than the start date!');
    } else {
      this.startTime = startDate.valueAsDate;
      this.endTime = endDate.valueAsDate;
      this.description = descriptionInput.value;
  
      this.vacationService.getAllVacations().subscribe(ret => {
        let maxId = 0;
        for (let v of ret) {
          if (v.id > maxId) {
            maxId = v.id;
          }
        }
        maxId += 1;
  
        let vacation = new Vacation(maxId, this.description, this.startTime, this.endTime, this.doctor.id);
        this.vacationService.getVacationAvailability(vacation).subscribe(ret => {
          if (!ret) {
            alert('Doctor has already had a scheduled vacation in period that you entered!');
          } else {
            this.vacationService.addVacation(vacation).subscribe(ret => {
              document.location.href = 'http://localhost:4200/doctor-vacations/' + vacation.doctorId.toString();
            });
          }
        });
      });
  
    }

  }

  private getTodayStringDate() {
    let today = new Date();
    let year = today.getFullYear().toString();
    let month = (today.getMonth() + 1);
    let day = today.getDate();
    let monthString = month.toString();
    if (month < 10) {
      monthString = '0' + month.toString();
    }
    let dayString = day.toString();
    if (day < 10) {
      dayString = '0' + day.toString();
    }
    let todayString = year + '-' + monthString + '-' + dayString;
    return todayString;
  }
}
