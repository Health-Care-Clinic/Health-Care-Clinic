import { Component, OnInit } from '@angular/core';
import { IPatient } from '../../model/patient/patient';
import {MatSnackBar} from '@angular/material/snack-bar';
import { PatientService } from '../../services/patient.service';

@Component({
  selector: 'app-malicious-patients',
  templateUrl: './malicious-patients.component.html',
  styleUrls: ['./malicious-patients.component.css']
})
export class MaliciousPatientsComponent implements OnInit {

  patients: IPatient[] = []
  displayedColumns: string[] = ['username', 'name', 'phone', 'email', 'block'];

  constructor(public _patientservice: PatientService, private _snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.getAllSuspiciousPatients();
  }

  getAllSuspiciousPatients() {
    this._patientservice.getAllSuspiciousPatients()
        .subscribe(patients => this.patients = patients);
  }

  block(patient: IPatient){
    patient.isBlocked = true;
    this._snackBar.open('Patient has been successfuly blocked!', 'Close', {duration: 5000});
    this.editPatient(patient);
  }

  editPatient(patient: IPatient) {
    this._patientservice.blockPatient(patient)
      .subscribe(data => {
        /* this.feedback.id = data.id */
        console.log(data)
        this.getAllSuspiciousPatients();
      })      
  }
}
