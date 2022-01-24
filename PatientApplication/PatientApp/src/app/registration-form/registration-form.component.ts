import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { IPatient, PatientWithPicture } from '../patient/ipatient';
import { Doctor } from './doctor';
import { IAllergen } from './allergen';
import { PatientService } from '../patient/patient.service';
import {MatSnackBar} from '@angular/material/snack-bar';

interface EmploymentStatus {
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

  emailControl: FormControl = new FormControl('', [Validators.required, Validators.email]);
  patientModel: IPatient = {
    id: 0,
    name: "",
    surname: "",
    birthDate: new Date(),
    parentName: "",
    address: "",
    phone:  "",
    employmentStatus: "",
    bloodType: "",
    gender: "",
    email:  "",
    username:  "",
    password: "",
    doctorDTO: {id: 0, name: "", surname: ""},
    allergens: [ ],
    dateOfRegistration:  new Date(),
    isBlocked: false,
    isActive: false
  }
  employmentStatuses: EmploymentStatus[] = [
    {value: 'student-0', viewValue: 'Student'},
    {value: 'employed-1', viewValue: 'Employed'},
    {value: 'unemployed-2', viewValue: 'Unemployed'},
    {value: 'retired-3', viewValue: 'Retired'}
  ];
  bloodTypes: BloodType[] = [
    {value: 'A-0', viewValue: 'A'},
    {value: 'B-1', viewValue: 'B'},
    {value: '0-2', viewValue: '0'},
    {value: 'AB-3', viewValue: 'AB'}
  ];
  doctors: Doctor[] = [];
  allergens: IAllergen[] = [];
  errorMessage : string  = '';
  repassword: string = '';
  usernames: Array<string> = [];
  selectedFile: any;
  selectedFileName : string = "unedfined";
  patientWithPicture: PatientWithPicture = {
    patient: this.patientModel,
    profilePicture: ""
  }



  constructor(public _patientservice: PatientService, private _snackBar: MatSnackBar)
  { }


  ngOnInit(): void {
    this.getDoctors();
    this.getAllergens();
    this.getAllUsernames();
  }

  getDoctors() {
    this._patientservice.getAvailableDoctors()
        .subscribe(doctors => this.doctors = doctors,
                    error => this.errorMessage = <any>error);
  }

  getAllergens() {
    this._patientservice.getAllAllergens()
        .subscribe(allergens => this.allergens = allergens,
                    error => this.errorMessage = <any>error);
  }

  getAllUsernames() {
    this._patientservice.getAllUsernames()
        .subscribe(usernames => this.usernames = usernames,
                    error => this.errorMessage = <any>error);
  }

  submit(): void {
    this.patientWithPicture.patient = this.patientModel

    if (this.selectedFile)
      this.patientWithPicture.profilePicture = this.selectedFile
    else
      this.patientWithPicture.profilePicture = ""

    this._patientservice.submitRequest(this.patientWithPicture)
    .subscribe(
      data => {
        console.log('Success!', data)
        this._snackBar.open('Registration request successfully submited! An activation mail has been sent to your inbox.', 'Close', {duration: 3000});
      },
      error => {
        console.log('Error!', error)
        this._snackBar.open('Failed to submit registration request!', 'Close', {duration: 3000});
      } 
    )

    console.log(this.patientWithPicture);
  }

  onFileSelected(event: any) {
    if(!event || !event.target) {
      return;
    }

    if (!event.target.files)
      this.selectedFile = null

    this.selectedFile = event.target.files[0];
    this.selectedFileName = event.target.files[0].name;
    let reader = new FileReader();
    reader.readAsDataURL(this.selectedFile);
    var self = this;


    reader.onload = function () {
      self.selectedFile = reader.result;
    }
    reader.onerror = function () {
      console.log("Error converting image!")
    };
  }

}


