import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import { EventSession, ScheduleEvent } from './event';

@Injectable({
  providedIn: 'root'
})
export class EventService {

  private _eventController = '/api/event';
  private _createEventSession = this._eventController + '/createEventSession'
  private session: EventSession = {
    id: 0,
    events: [],
    resultedInSucces: false,
    userId: 1
  }

  public eventQueue: ScheduleEvent[] = []

  constructor(private _http : HttpClient) {}

  finishEventSession(success: boolean) {
    console.log(this.eventQueue)
    this.session.events = this.eventQueue
    this.session.resultedInSucces = success
    this.session.userId = this.eventQueue[0].userId
    this.eventQueue = []
    console.log(this.session)

    const body=JSON.stringify(this.session);
    console.log(body)
    return this._http.post(this._createEventSession, body)
  }

  sendEvent() {
    
  }

  private handleError(err : HttpErrorResponse) {
      console.log(err.message);
      return Observable.throw(err.message);
      throw new Error('Method not implemented.');
  }

}
