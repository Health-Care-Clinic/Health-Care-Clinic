import { Component,Input, OnInit } from '@angular/core';
import { Doctor } from '../registration-form/doctor';
import { AppointmentService } from '../service/appointment.service';
import { SurveyService } from '../survey/survey.service';
import { IAppointment } from '../service/IAppointment';
import { ISurvey } from '../survey/survey';
import { Router } from '@angular/router';

@Component({
  selector: 'app-appointments',
  templateUrl: './appointments.component.html',
  styleUrls: ['./appointments.component.css']
})

export class AppointmentsComponent implements OnInit {

  constructor(private _appointmentService: AppointmentService, private _surveyService: SurveyService, private router: Router) { }

  @Input() id! : number;
  appointments : IAppointment[] = [];
  appointment!: IAppointment;
  currentDate = new Date();
  currentDatePlusTwoDays = new Date(new Date().getTime() + 2 * 24 * 60 * 60 * 1000);
  errorMessage : string = "";
  displayedColumns: string[] = ['AppointmentId','Room','DoctorName', 'Date', 'Cancelled','Cancelation','SurveyId']; 


  ngOnInit(): void {
    this.getAppointmetsForPatient(Number(localStorage.getItem('id')))
  }

  getAppointmetsForPatient(id: number) {
    this._appointmentService.getAppointmetsForPatient(id)
        .subscribe(data =>  this.appointments = data,
                   error => this.errorMessage = <any>error);   
  }

  goToSurvey(appointment: IAppointment): void {
    const navigationDetails: string[] = ['/survey'];
    this._surveyService.appointmentId = appointment.id;
    this.router.navigate(navigationDetails);
  }

  cancelAppointment(appointment :IAppointment){
    this._appointmentService.cancelAppointment(appointment.id)
        .subscribe(data => this.appointment = data,
                   error => this.errorMessage = <any>error);
    appointment.isCancelled = true;
    this.getAppointmetsForPatient(appointment.patientId);
    window.alert('Your appointment is cancelled!');
  }

  compare(appointmentDate: Date, tempDate: Date)
  {
    var appointmentTime = new Date(appointmentDate);
    if(appointmentTime.getTime() < tempDate.getTime())
    {
      return true;
    }
    else
    {
      return false;
    }
  }
}
