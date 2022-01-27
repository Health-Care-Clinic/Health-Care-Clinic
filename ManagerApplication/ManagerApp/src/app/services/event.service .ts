import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Event } from '../model/event';
import { Transfer } from '../model/transfer';

@Injectable({
  providedIn: 'root'
})
export class EventService {
  private getAllEventsUrl: string;
  private addNewEventUrl: string;
  private getMostFrequentEventUrl: string;

  constructor(private _http: HttpClient) {
    this.getAllEventsUrl = '/api/event/getAllEvents'
    this.addNewEventUrl = '/api/event/createEvent';
    this.getMostFrequentEventUrl = 'api/event/getMostFrequentEvent'
  }

  public getAllEvents() : Observable<Array<Event>> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.get<Array<Event>>(this.getAllEventsUrl, {headers: headers});
  }

  public addNewEvent(event: Event) : Observable<Event> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');

    return this._http.post<Event>(this.addNewEventUrl, event, {headers: headers});
  }

  public getMostFrequentEvent() : Observable<Transfer> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');

    return this._http.get<Transfer>(this.getMostFrequentEventUrl, {headers: headers});
  }
}
