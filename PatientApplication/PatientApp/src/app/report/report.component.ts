import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PatientService } from '../patient/patient.service';
import { IAppointment } from '../service/IAppointment';
import { IReport } from './IReport';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit {

  appointment !: IAppointment;
  constructor(private _patientService : PatientService,private router : Router) { }

  ngOnInit(): void {
    this.appointment = this._patientService.appointment;
    if(this.appointment == null)
      this.router.navigateByUrl('medical-record');
  }

  

}
