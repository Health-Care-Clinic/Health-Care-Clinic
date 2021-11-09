import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IFeedback } from '../model/feedback/IFeedback';
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

    editFeedback(feedback : IFeedback):Observable<any>{
        const body = JSON.stringify(feedback);
        return this._http.put<any>(this._feedbackUrl + '/' + feedback.id, body)
    }

    getPublishedFeedbacks() : Observable<IFeedback[]>{
        return this._http.get<IFeedback[]>(this._feedbackUrl + 'published')
                         .do(data =>  console.log('All: ' + JSON.stringify(data)))
                         .catch(this.handleError);
    }

    private handleError(err : HttpErrorResponse) {
        console.log(err.message);
        return Observable.throw(err.message);
        throw new Error('Method not implemented.');
    }
}