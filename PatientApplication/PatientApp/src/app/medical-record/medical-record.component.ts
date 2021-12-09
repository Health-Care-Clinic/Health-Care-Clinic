import { Component, OnInit } from '@angular/core';
import { IPatient } from '../patient/ipatient';
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
  errorMessage : string  = '';

  constructor(public _patientservice: PatientService) { }

  ngOnInit(): void {
    this.getPatient(8);
  }

  getPatient(id: number) {
    this._patientservice.getPatient(id)
        .subscribe(patientModel => this.patientModel = patientModel,
                    error => this.errorMessage = <any>error);     
  }

}
