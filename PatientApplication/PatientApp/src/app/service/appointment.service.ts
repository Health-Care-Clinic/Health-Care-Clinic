import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IAppointment } from './IAppointment';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import { Doctor } from '../registration-form/doctor';
import { ISurvey } from '../survey/survey';
import { AppointmentsComponent } from '../appointments/appointments.component';
import { GettingTermsDTO } from '../recommendation-scheduling/gettingTermsDTO';
import { DoctorWithSpecialty } from '../recommendation-scheduling/doctor-with-specialty';
import { AppointmentWithDoctorId } from '../recommendation-scheduling/appointment-doctorId';

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {

  appDto: AppointmentWithDoctorId = {
    id : 0,
    patientId : 0,
    doctorId : 0,
    roomId : 0,
    isCancelled : false,
    isDone : false,
    date : new Date(),
    surveyId : 0
  }

  private _appointmentUrl = '/api/appointment';
  private _getAppointmentsForPatient = this._appointmentUrl + '/getAppointmentsByPatientId/';
  private _cancelAppointment = this._appointmentUrl + '/cancelAppointment/';
  private _getDoctors = '/api/doctor/allDoctors';
  private _getAvailableTermsForDoctorPriority = this._appointmentUrl + '/freeTermsForDoctor';
  private _getAvailableTermsForDateRangePriority = this._appointmentUrl + '/freeTermsForDateRange';
  private _schedule = this._appointmentUrl + '/createAppointment';

  constructor(private _http : HttpClient){}

  getAppointmetsForPatient(id: number): Observable<IAppointment[]> {
      return this._http.get<IAppointment[]>(this._getAppointmentsForPatient+id)
                           .do(data =>  console.log('Iz service-a: ' + JSON.stringify(data)))
                           .catch(this.handleError);
    }

    cancelAppointment(id : number):Observable<IAppointment>{
      const body = JSON.stringify(id);
      return this._http.put<IAppointment>(this._cancelAppointment + id, body)
                       .catch(this.handleError);
  }

  private handleError(err : HttpErrorResponse) {
    console.log(err.message);
    return Observable.throw(err.message);
    throw new Error('Method not implemented.');
  } 

  getDoctors(): Observable<DoctorWithSpecialty[]> {
    return this._http.get<DoctorWithSpecialty[]>(this._getDoctors)
                           .do(data =>  console.log('Doctors: ' + JSON.stringify(data)))
                           .catch(this.handleError);
  }

  getAvailableTermsForPriority(priority: string, dto: GettingTermsDTO) : Observable<any> {
    
    const headers = { 'content-type': 'application/json'}  
    dto.from = new Date(Date.UTC(dto.from.getFullYear(), dto.from.getMonth(), dto.from.getDate(), dto.from.getHours(), dto.from.getMinutes()));
    dto.to = new Date(Date.UTC(dto.to.getFullYear(), dto.to.getMonth(), dto.to.getDate(), dto.to.getHours(), dto.to.getMinutes()));
    const body=JSON.stringify(dto).toLocaleString();
    console.log('GettingTermsDTO: ' + body)
    
    var httpAnswer = new Observable<any>();
    if (priority == 'Doctor')
      httpAnswer = this._http.post(this._getAvailableTermsForDoctorPriority, body,{'headers':headers})
    else if (priority == 'DateRange')
      httpAnswer = this._http.post(this._getAvailableTermsForDateRangePriority, body, {'headers': headers});

    return httpAnswer;
  }

  schedule(term: Date, doctorId: number, patientId: number): Observable<any> {

    this.appDto.date = term;
    this.appDto.doctorId = doctorId;
    this.appDto.patientId = patientId;
    const headers = { 'content-type': 'application/json'}  
    const body=JSON.stringify(this.appDto);
    console.log('appDto: ' + body)
    return this._http.post(this._schedule, body,{'headers':headers})
  }
}
