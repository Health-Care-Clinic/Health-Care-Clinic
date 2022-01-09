import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IDoctor } from 'src/app/model/patient/doctor';
import { Vacation } from 'src/app/model/vacation';
import { DoctorsService } from 'src/app/services/doctors.service';
import { VacationService } from 'src/app/services/vacation.service';

@Component({
  selector: 'app-change-doctor-vacation',
  templateUrl: './change-doctor-vacation.component.html',
  styleUrls: ['./change-doctor-vacation.component.css']
})
export class ChangeDoctorVacationComponent implements OnInit {

  oldVacation: Vacation;
  oldStartTime: string;
  oldEndTime: string;
  doctor: IDoctor;
  startTime: Date;
  endTime: Date;
  description: string;
  today: string;
  found: boolean;

  constructor(private _route: ActivatedRoute, private vacationService: VacationService, private doctorService: DoctorsService) { }

  ngOnInit(): void {
    this.found = false;

    var vacationId = +this._route.snapshot.paramMap.get('idvc');
    this.vacationService.getAllVacations().subscribe(ret => {
      for (let v of ret) {
        if (v.id == vacationId) {
          this.oldVacation = v;
          this.doctorService.findById(v.doctorId).subscribe(ret => {
            this.doctor = ret;
          });

          this.found = true;
          
          this.oldStartTime = v.startTime.toString().split('T')[0];
          this.oldEndTime = v.endTime.toString().split('T')[0];

          this.today = this.getTodayStringDate();

          break;
        }
      }
    });
    
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
        let vacation = new Vacation(this.oldVacation.id, this.description, this.startTime, this.endTime, this.oldVacation.doctorId);
        this.vacationService.getChangedVacationAvailability(vacation).subscribe(ret => {
          if (!ret) {
            alert('Doctor has already had a scheduled vacation in period that you entered!');
          } else {
            this.vacationService.changeVacation(vacation).subscribe(ret => {
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
