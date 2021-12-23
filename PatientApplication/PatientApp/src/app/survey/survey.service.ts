import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ISurvey } from './survey'; 
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import { throwError } from 'rxjs';
import { ISurveyQuestion } from './survey-question';


@Injectable()
export class SurveyService{
    private _surveyUrl = '/api/survey/';
    private questions: ISurveyQuestion[] = []
    public appointmentId!: number;

    constructor(private _http : HttpClient){}

    getSurvey(id: number) : Observable<ISurvey>{
        const headers = { 'content-type': 'application/json',
                      'Authorization': 'Bearer ' + localStorage.getItem('jwtToken')} 
        return this._http.get<ISurvey>(this._surveyUrl + 'new/'+ id, { 'headers': headers })
                         .do(data =>  console.log('All: ' + JSON.stringify(data)))
                         .catch(this.handleError);
    }

    addSurvey(survey : ISurvey):Observable<any>{
        survey.surveyCategories.forEach(category => {
            category.surveyQuestions.forEach(question => {
                this.questions.push(question);
            });
        });
        const body = JSON.stringify(this.questions);
        const headers = { 'content-type': 'application/json',
        'Authorization': 'Bearer ' + localStorage.getItem('jwtToken')} 
        return this._http.put<any>(this._surveyUrl + '/' + survey.id, body, {'headers':headers})
    }

    private handleError(err : HttpErrorResponse) {
        console.log(err.message);
        return throwError(err.message);
    }
}