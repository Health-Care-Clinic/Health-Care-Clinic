import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ISurvey } from './survey'; 
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import { throwError } from 'rxjs';

@Injectable()
export class SurveyService{
    private _surveyUrl = '/api/survey/';

    constructor(private _http : HttpClient){}

    getSurvey() : Observable<ISurvey>{
        return this._http.get<ISurvey>(this._surveyUrl + 'new')
                         .do(data =>  console.log('All: ' + JSON.stringify(data)))
                         .catch(this.handleError);
    }

    addSurvey(survey : ISurvey):Observable<any>{
        const body = JSON.stringify(survey);
        const headers = { 'content-type': 'application/json'}
        return this._http.put<any>(this._surveyUrl + '/' + survey.id, body, {'headers':headers})
    }

    private handleError(err : HttpErrorResponse) {
        console.log(err.message);
        return throwError(err.message);
    }

}