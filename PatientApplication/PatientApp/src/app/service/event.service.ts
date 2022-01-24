import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import { ScheduleEvent } from './event';

@Injectable({
  providedIn: 'root'
})
export class EventService {

  private _eventController = '/api/event';
  private _createEvent = this._eventController + '/createEvent'

  constructor(private _http : HttpClient) {}

  createEvent(event: ScheduleEvent) : Observable<any>{
    const body=JSON.stringify(event);
    console.log(body)
    return this._http.post(this._createEvent, body)
  }

  private handleError(err : HttpErrorResponse) {
      console.log(err.message);
      return Observable.throw(err.message);
      throw new Error('Method not implemented.');
  }

}
