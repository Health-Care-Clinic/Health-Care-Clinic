import { Component, OnInit } from '@angular/core';
import { IPatient, PatientWithPicture } from '../patient/ipatient';
import { PatientService } from '../patient/patient.service';

@Component({
  selector: 'app-medical-record',
  templateUrl: './medical-record.component.html',
  styleUrls: ['./medical-record.component.css']
})
export class MedicalRecordComponent implements OnInit {

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

  patientWithPicture: PatientWithPicture = {
    patient: this.patientModel,
    profilePicture: ""
  }

  errorMessage : string  = '';

  constructor(public _patientservice: PatientService) { }

  ngOnInit(): void {
    this.getPatient(Number(localStorage.getItem('id')));
  }

  getPatient(id: number) {
    this._patientservice.getPatient(id)
        .subscribe(data => {
          this.patientWithPicture = data
          this.patientModel = this.patientWithPicture.patient
          console.log(this.patientWithPicture)
        },
          error => this.errorMessage = <any>error);     

    /* location.reload() */
  }

}
