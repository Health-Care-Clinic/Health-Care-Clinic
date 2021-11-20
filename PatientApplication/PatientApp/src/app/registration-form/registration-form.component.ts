import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { Patient } from '../patient/ipatient';
import { PatientService } from '../patient/patient.service';

@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.css']
})
export class RegistrationFormComponent implements OnInit {

  emailControl: FormControl = new FormControl('', [Validators.required, Validators.email]);
  patientModel: Patient = new Patient();
  

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
