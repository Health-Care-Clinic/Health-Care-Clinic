import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IAppointment } from './IAppointment';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import { Doctor } from '../registration-form/doctor';
import { ISurvey } from '../survey/survey';
import { AppointmentsComponent } from '../appointments/appointments.component';

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {

  private _appointmentUrl = '/api/appointment';
  private _getAppointmentsForPatient = this._appointmentUrl + '/getAppointmentsByPatientId/';
  private _cancelAppointment = this._appointmentUrl + '/cancelAppointment/';
  private _getAllSpecializations = this._appointmentUrl + '/getAllSpecialties';
  private _getDoctorsBySpecialty = this._appointmentUrl + '/getDoctorsBySpecialty/';
  private _getTermsForSelectedDoctor = this._appointmentUrl + '/getTermsForSelectedDoctor/';
  private _createAppointment = this._appointmentUrl + '/createAppointment';

    constructor(private _http : HttpClient){}

    getAppointmetsForPatient(id: number): Observable<IAppointment[]> {
      return this._http.get<IAppointment[]>(this._getAppointmentsForPatient+id)
                           .do(data =>  console.log('Iz service-a: ' + JSON.stringify(data)))
                           .catch(this.handleError);
    }

    cancelAppointment(id : number):Observable<any>{
      const body = JSON.stringify(id);
      return this._http.put<any>(this._cancelAppointment + id, body)
  }

    getAllSpecialties(): Observable<string[]> {
      return this._http.get<string[]>(this._getAllSpecializations)
                          .do(data =>  console.log('All: ' + JSON.stringify(data)))
                          .catch(this.handleError);
    }

    getDoctorsBySpecialty(specialty: string): Observable<Doctor[]> {
      return this._http.get<Doctor[]>(this._getDoctorsBySpecialty + JSON.stringify(specialty))
                          .do(data => console.log('All: ' + JSON.stringify(data)))
                          .catch(this.handleError);
    }

    getTermsForSelectedDoctor(doctorId: number, date: Date): Observable<string[]> {
      return this._http.get<string[]>(this._getTermsForSelectedDoctor + doctorId + '/' + JSON.stringify(date))
                          .do(data =>  console.log('All: ' + JSON.stringify(data)))
                          .catch(this.handleError);
    }

    createAppointment(appointment : IAppointment): Observable<any> {
      const headers = { 'content-type': 'application/json'}
      const body=JSON.stringify(appointment);
      console.log(body)
      return this._http.post(this._createAppointment, body,{'headers':headers})
    }

    private handleError(err : HttpErrorResponse) {
        console.log(err.message);
        return Observable.throw(err.message);
        throw new Error('Method not implemented.');
    }
}
