import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IFeedback } from './IFeedback';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';


const headers= new HttpHeaders()
  .set('content-type', 'application/json')
  .set('Authorization', 'Bearer ' + localStorage.getItem('jwtToken'));

@Injectable()
export class FeedbackService{
    private _feedbackUrl = '/api/feedbackMessage/';

    constructor(private _http : HttpClient){}

    getPublishedFeedbacks() : Observable<IFeedback[]>{
        return this._http.get<IFeedback[]>(this._feedbackUrl + 'published',  { 'headers': headers })
                         .do(data =>  console.log('All: ' + JSON.stringify(data)))
                         .catch(this.handleError);
    }

    private handleError(err : HttpErrorResponse) {
        console.log(err.message);
        return Observable.throw(err.message);
        throw new Error('Method not implemented.');
    }
}
