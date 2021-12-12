import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ISurveyStatistics } from '../model/survey-observation/survey-statistics';
import { ISurveyCategoryStatistics } from '../model/survey-observation/survey-category-statistics';
import { ISurveyQuestionStatistics } from '../model/survey-observation/survey-question-statistics';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import { throwError } from 'rxjs';

@Injectable()
export class SurveyObservationService {
    private _surveyUrl = '/api/survey/';
    private questions: ISurveyQuestionStatistics[] = []

    constructor(private _http : HttpClient){}

    getSurveyStatistics() : Observable<ISurveyStatistics>{
        return this._http.get<ISurveyStatistics>(this._surveyUrl + 'statistics')
                         .do(data =>  console.log('All: ' + JSON.stringify(data)))
                         .catch(this.handleError);
    }

    private handleError(err : HttpErrorResponse) {
        console.log(err.message);
        return throwError(err.message);
    }
}
