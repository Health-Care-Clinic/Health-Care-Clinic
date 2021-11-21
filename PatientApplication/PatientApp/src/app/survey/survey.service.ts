import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ISurvey } from './survey'; 
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';

@Injectable()
export class SurveyService{
    private _surveyUrlGetAll = '/api/survey/';
    private _surveyUrlSubmit = '/api/survey/submit';

    constructor(private _http : HttpClient){}

    getSurvey() : Observable<ISurvey>{
        return this._http.get<ISurvey>(this._surveyUrlGetAll + 'new')
                         .do(data =>  console.log('All: ' + JSON.stringify(data)))
                         .catch(this.handleError);
    }

    addSurvey(survey: ISurvey): Observable<any> { 
        const headers = { 'content-type': 'application/json'}  
        const body=JSON.stringify(survey);
        console.log(body)
        return this._http.post(this._surveyUrlSubmit, body,{'headers':headers})
                         .catch(this.handleError);
    }

    private handleError(err : HttpErrorResponse) {
        console.log(err.message);
        return Observable.throw(err.message);
        throw new Error('Method not implemented.');
    }

}