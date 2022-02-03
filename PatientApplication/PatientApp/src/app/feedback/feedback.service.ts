import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Feedback } from './feedback';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FeedbackService {

  private _feedbackUrl = '/api/feedbackMessage/submit';

  constructor(private _http: HttpClient) { }

  addFeedback(feedback:Feedback): Observable<any> {

    feedback.date = new Date().toString();
    const body=JSON.stringify(feedback);
    console.log(body)
    return this._http.post(this._feedbackUrl, body)
  }

}
