import { invalid } from '@angular/compiler/src/render3/view/util';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { AppointmentWithDoctorId } from '../recommendation-scheduling/appointment-doctorId';
import { Doctor } from '../registration-form/doctor';
import { AppointmentService } from '../service/appointment.service';
import { IAppointment } from '../service/IAppointment';

@Component({
  selector: 'app-standard-scheduling',
  templateUrl: './standard-scheduling.component.html',
  styleUrls: ['./standard-scheduling.component.css']
})
export class StandardSchedulingComponent implements OnInit {
  

  patientId: number = Number(localStorage.getItem('id'));
  specializations : Array<string> = [];
  selectedSpecialty : string = '';
  doctors : Doctor[] = [];
  selectedDoctor : Doctor = {id: 0, name: "", surname: ""};
  selectedDate : Date = new Date();
  terms : string[] = [];
  selectedTerm : string = '';
  errorMessage : string  = '';
  today : Date;
  nextDisabled : boolean;

  firstFormGroup : FormGroup = this._formBuilder.group({
    firstCtrl: ['', Validators.required], });
  secondFormGroup: FormGroup = this._formBuilder.group({
    secondCtrl: ['', Validators.required], });
  thirdFormGroup : FormGroup = this._formBuilder.group({
    thirdCtrl: ['', Validators.required], });
  fourthFormGroup : FormGroup = this._formBuilder.group({
    fourthCtrl: ['', Validators.required], });

  constructor(private _formBuilder: FormBuilder, public _appointmentService : AppointmentService, private _snackBar: MatSnackBar, private router: Router) {
    this.today = new Date();
    this.nextDisabled = true;
   }

  ngOnInit(): void {
    
  }

  getAllSpecialties() {
    this._appointmentService.getAllSpecialties()
        .subscribe(specializations => this.specializations = specializations,
                    error => this.errorMessage = <any>error);
  }

  getDoctorsBySpecialty() {
    this._appointmentService.getDoctorsBySpecialty(this.selectedSpecialty)
        .subscribe(data => this.doctors = data,
                    error => this.errorMessage = <any>error);
  }

  getTermsForSelectedDoctor() {
    this._appointmentService.getTermsForSelectedDoctor(this.selectedDoctor.id, this.selectedDate)
        .subscribe(terms => this.terms = terms,
                    error => this.errorMessage = <any>error);
  }

  confirm() {
    
    this._appointmentService.schedule(new Date(this.selectedTerm), this.selectedDoctor.id, this.patientId)
        .subscribe(
          data => {
            console.log('Success!', data)
            this.router.navigateByUrl('/medical-record').then(() => {
              this._snackBar.open('You have been successfully scheduled an appointment', 'Close', {duration: 3000});
            });
          },
              error => this._snackBar.open('Failed to create appointment!', 'Close', {duration: 3000})
        )

    console.log(this.selectedDate, this.selectedDoctor.id, this.patientId);  
  }

  enableNext() {
    this.nextDisabled = false;
  }
}
