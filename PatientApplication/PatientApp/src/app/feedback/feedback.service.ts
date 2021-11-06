import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Feedback } from './feedback';

@Injectable({
  providedIn: 'root'
})
export class FeedbackService {

  _url = "localhost:6281/api/";

  constructor(private _http: HttpClient) { }

  generate(feedback : Feedback) {
    return this._http.post<any>(this._url, feedback);
  }
}
