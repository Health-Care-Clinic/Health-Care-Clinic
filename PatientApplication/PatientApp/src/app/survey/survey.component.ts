import { Component, OnInit } from '@angular/core';
import { ISurvey } from './survey';
import { ISurveyQuestion } from './survey-question';
import { SurveyService } from './survey.service';

@Component({
  selector: 'app-survey',
  templateUrl: './survey.component.html',
  styleUrls: ['./survey.component.css']
})
export class SurveyComponent implements OnInit {
  survey : ISurvey = {
      id : 0,
      patientId : 0,
      appointmentId : 0,
      surveyQuestions : []
  };
  errorMessage : string  = '';
  questionTypeTitles : string[] = ["Doctor", "Medical stuff", "Hospital"]

  constructor(private _surveyService : SurveyService) { }

  ngOnInit(): void {
    this.showSurvey();
  }



  showSurvey() {
    this._surveyService.getSurvey()
        .subscribe(survey => this.survey = survey,
                    error => this.errorMessage = <any>error); 
  }

  submit() {
    this._surveyService.addSurvey(this.survey)
        .subscribe(data => console.log('Success!', data),
                    error => console.log('Error!', error)) 
      console.log(this.survey);
      window.alert('Your survey has been submited.');
    }

}
