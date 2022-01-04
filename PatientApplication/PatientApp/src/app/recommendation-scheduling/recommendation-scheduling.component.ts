import { Component, OnInit, ViewChild } from '@angular/core';
import {MatSnackBar} from '@angular/material/snack-bar';
import { DoctorWithSpecialty } from './doctor-with-specialty';
import {FormGroup, FormControl} from '@angular/forms';
import { AppointmentService } from '../service/appointment.service';
import { GettingTermsDTO } from '../recommendation-scheduling/gettingTermsDTO';
import { TermsInDateRange } from './termsInDateRange';
import { TermsInDateRangeForDoctor } from './termsInDateRangeForDoctor';
import { MatPaginator } from '@angular/material/paginator';
import { Router } from '@angular/router';

@Component({
  selector: 'app-recommendation-scheduling',
  templateUrl: './recommendation-scheduling.component.html',
  styleUrls: ['./recommendation-scheduling.component.css']
})
export class RecommendationSchedulingComponent implements OnInit {
  minDate = new Date();
  range = new FormGroup({
    start: new FormControl(),
    end: new FormControl(),
  });
  doctors: DoctorWithSpecialty[] = [];
  chosenPriority: string = '';
  termsForDoctorAsPriority: Date[] = [];
  termsForDateRangeAsPriority: TermsInDateRange = {
    initiallyPickedDoctor : {
      id: 0,
      name: '',
      surname: '',
      specialty: ''
    },
    specialty: '',
    beginningDateTime: new Date(),
    endingDateTime: new Date(),
    termsInDateRangeForDoctors: []
  };
  patientId: number = 1;
  dto: GettingTermsDTO = {
    doctorId: 0,
    specialty: '',
    beginningDateTime: new Date(),
    endingDateTime: new Date()
  }
  errorMessage : string  = '';

  constructor(private _snackBar: MatSnackBar, public _appointmentService: AppointmentService, private router: Router) { }

  ngOnInit(): void {
    var divForDoctorAsPriority = document.getElementById('termsForDoctorAsPriorityDiv');
    if (divForDoctorAsPriority != null) {
      divForDoctorAsPriority.style.display = 'none';
    }
    var divForDateRangeAsPriority = document.getElementById('termsForDateRangeAsPriorityDiv');
    if (divForDateRangeAsPriority != null) {
      divForDateRangeAsPriority.style.display = 'none';
    }
    
    this.getDoctors();
  }

  getDoctors() {
    this._appointmentService.getDoctors()
        .subscribe(doctors => this.doctors = doctors,
                    error => this.errorMessage = <any>error);
  }

  getAvailableTerms(priority: string) {
    this.chosenPriority = priority;

    this.dto.beginningDateTime = this.range.value.start;
    this.dto.endingDateTime = this.range.value.end;
    if (this.dto.beginningDateTime == null || this.dto.endingDateTime == null)
      this._snackBar.open('You have to select a date range first!', 'Close', {duration: 5000});
    if (this.dto.doctorId == 0)
      this._snackBar.open('You have to select a doctor first!', 'Close', {duration: 5000});
    
    if (this.dto.beginningDateTime != null && this.dto.endingDateTime != null && this.dto.doctorId > 0) {
      this.dto.specialty = this.getSpecialtyOfSelectedDoctor(this.dto.doctorId);

      var divForDoctorAsPriority = document.getElementById('termsForDoctorAsPriorityDiv');
      var divForDateRangeAsPriority = document.getElementById('termsForDateRangeAsPriorityDiv');

      if (divForDoctorAsPriority != null && divForDateRangeAsPriority != null) {
        if (this.chosenPriority == 'DateRange') {
          divForDateRangeAsPriority.style.display = 'initial';
          divForDoctorAsPriority.style.display = 'none';
          
          this._appointmentService.getAvailableTermsForPriority(priority, this.dto)
            .subscribe(data => this.termsForDateRangeAsPriority = data, 
              error => this.errorMessage = <any>error);
        } else if (this.chosenPriority == 'Doctor') {
          divForDoctorAsPriority.style.display = 'initial';
          divForDateRangeAsPriority.style.display = 'none';

          this._appointmentService.getAvailableTermsForPriority(priority, this.dto)
            .subscribe(data => this.termsForDoctorAsPriority = data,
              error => this.errorMessage = <any>error);
        }
      }
    }
  }

  getSpecialtyOfSelectedDoctor(doctorId : number) {
    var specialty : string = '';

    for (let d of this.doctors) {
      if (d.id == doctorId) {
        specialty = d.specialty;
        break;
      }
    }

    return specialty;
  }

  schedule(term: Date) {
    this._appointmentService.schedule(term, this.dto.doctorId, this.patientId)
    .subscribe(
      data => console.log('Success!', data),
      error => console.log('Error!', error)
    )
    
    this.router.navigateByUrl('/medical-record');
    console.log(term);
    this._snackBar.open('You have been successfully scheduled an appointment', 'Close', {duration: 3000});
  }
}
