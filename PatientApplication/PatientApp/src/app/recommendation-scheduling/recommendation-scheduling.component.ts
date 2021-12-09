import { Component, OnInit } from '@angular/core';
import {MatSnackBar} from '@angular/material/snack-bar';
import { DoctorWithSpecialty } from './doctor-with-specialty';
import {FormGroup, FormControl} from '@angular/forms';

@Component({
  selector: 'app-recommendation-scheduling',
  templateUrl: './recommendation-scheduling.component.html',
  styleUrls: ['./recommendation-scheduling.component.css']
})
export class RecommendationSchedulingComponent implements OnInit {

  range = new FormGroup({
    start: new FormControl(),
    end: new FormControl(),
  });
  fromDate: Date = new Date();
  toDate: Date = new Date();
  doctorId: number = 0;
  doctors: DoctorWithSpecialty[] = [];
  terms: Date[] = [];
  patientId: number = 1;

  constructor(private _snackBar: MatSnackBar/* , public _appointmentService: AppointmentService */) { }

  ngOnInit(): void {
    /* this.getDoctors(); */
  }

  /* getDoctors() {
    this._appointmentService.getDoctors()
        .subscribe(doctors => this.doctors = doctors,
                    error => this.errorMessage = <any>error);
  }

  getAvailableTerms(priority: string): Observable<any> {
    if (this.fromDate == new Date() || this.toDate == new Date()) {
      this._snackBar.open('You have to select some date range first', 'Close', {duration: 5000});
      if (this.doctorId == 0)
        this._snackBar.open('You have to select some doctor first', 'Close', {duration: 5000});
    }
    else {
      this._appointmentService.getAvailableTermsForPriority(priority)
      .subscribe(terms => this.terms = terms,
                  error => this.errorMessage = <any>error);
    }    
  }

  schedule(term: Date): Observable<any> {
    this._appointmentService.schedule(term, this.doctorId, this.patientId);
  } */

}
