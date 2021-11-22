import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { Patient } from '../patient/ipatient';
import { PatientService } from '../patient/patient.service';

interface EmploymentStatus {
  value: string;
  viewValue: string;
}

interface Doctor {
  value: string;
  viewValue: string;
}

interface BloodType {
  value: string;
  viewValue: string;
}

@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.css']
})

export class RegistrationFormComponent implements OnInit {
  allergensCtrl : FormControl = new FormControl('');
  emailControl: FormControl = new FormControl('', [Validators.required, Validators.email]);
  patientModel: Patient = new Patient();
  employmentStatuses: EmploymentStatus[] = [
    {value: 'student-0', viewValue: 'Student'},
    {value: 'employed-1', viewValue: 'Employed'},
    {value: 'unemployed-2', viewValue: 'Unemployed'},
    {value: 'retired-3', viewValue: 'Retired'}
  ];
  doctors: Doctor[] = [];
  alergens: string[] = ["kikiriki", "semenke", "med"]
  bloodTypes: BloodType[] = [
    {value: 'A-0', viewValue: 'A'},
    {value: 'B-1', viewValue: 'B'},
    {value: '0-2', viewValue: '0'},
    {value: 'AB-3', viewValue: 'AB'}
  ];
  

  constructor(
    public _patientservice: PatientService,
    ) { }


  ngOnInit(): void {

  }

  submit(): void {

    this._patientservice.submitRequest(this.patientModel)
    .subscribe(
      data => console.log('Success!', data),
      error => console.log('Error!', error)
    )

    window.alert('Registration request successfully submited!');
    this.patientModel = new Patient();
  }

}
