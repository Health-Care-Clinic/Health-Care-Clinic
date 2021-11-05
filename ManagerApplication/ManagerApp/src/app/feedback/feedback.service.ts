import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IFeedback } from './IFeedback';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';

@Injectable()
export class FeedbackService{
    private _feedbackUrl = '/api/feedbackMessage/';

    constructor(private _http : HttpClient){}

    getFeedbacks() : Observable<IFeedback[]>{
        return this._http.get<IFeedback[]>(this._feedbackUrl)
                         .do(data =>  console.log('All: ' + JSON.stringify(data)))
                         .catch(this.handleError);
    }

    addFeedback(feedback:IFeedback): Observable<any> {
        const headers = { 'content-type': 'application/json'}  
        const body=JSON.stringify(feedback);
        console.log(body)
        return this._http.post(this._feedbackUrl, body,{'headers':headers})
      }
    
    editFeedback(feedback : IFeedback):Observable<any>{
        const body = JSON.stringify(feedback);
        return this._http.put<any>(this._feedbackUrl + '/' + feedback.id, body)
    }

    private handleError(err : HttpErrorResponse) {
        console.log(err.message);
        return Observable.throw(err.message);
        throw new Error('Method not implemented.');
    }
}