import { Component, OnInit, ViewChild } from '@angular/core';
import {MatSnackBar} from '@angular/material/snack-bar';
import { DoctorWithSpecialty } from './doctor-with-specialty';
import {FormGroup, FormControl} from '@angular/forms';
import { AppointmentService } from '../service/appointment.service';
import { GettingTermsDTO } from '../recommendation-scheduling/gettingTermsDTO';
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
  terms: Date[] = [];
  patientId: number = Number(localStorage.getItem('id'));
  dto: GettingTermsDTO = {
    doctorId: 0,
    from: new Date(),
    to: new Date()
  }
  errorMessage : string  = '';

  constructor(private _snackBar: MatSnackBar, public _appointmentService: AppointmentService, private router: Router) { }

  ngOnInit(): void {
    this.getDoctors();
  }

  getDoctors() {
    this._appointmentService.getDoctors()
        .subscribe(doctors => this.doctors = doctors,
                    error => this.errorMessage = <any>error);
  }

  getAvailableTerms(priority: string) {
    this.dto.from = this.range.value.start;
    this.dto.to = this.range.value.end;
    if (this.dto.from == null || this.dto.to == null)
      this._snackBar.open('You have to select some date range first', 'Close', {duration: 5000});
    if (this.dto.doctorId == 0)
      this._snackBar.open('You have to select some doctor first', 'Close', {duration: 5000});
    
    if (this.dto.from != null && this.dto.to != null && this.dto.doctorId > 0) {
      this._appointmentService.getAvailableTermsForPriority(priority, this.dto)
      .subscribe(data => this.terms = data,
                  error => this.errorMessage = <any>error);
    }    
  }

  schedule(term: Date) {
    this._appointmentService.schedule(term, this.dto.doctorId, this.patientId)
    .subscribe(
      data => {
        console.log('Success!', data)
        this.router.navigateByUrl('/medical-record')
      },
      error => console.log('Error!', error)      
    )
    
    console.log(term);
    this._snackBar.open('You have been successfully scheduled an appointment', 'Close', {duration: 3000});
  }

}
