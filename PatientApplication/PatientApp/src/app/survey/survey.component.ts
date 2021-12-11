import { Component, OnInit } from '@angular/core';
import { ISurvey } from './survey';
import { ISurveyQuestion } from './survey-question';
import { ISurveyCategory } from './survey-category';
import { SurveyService } from './survey.service';
import {MatSnackBar} from '@angular/material/snack-bar';
import { AppointmentService } from '../service/appointment.service';

@Component({
  selector: 'app-survey',
  templateUrl: './survey.component.html',
  styleUrls: ['./survey.component.css']
})
export class SurveyComponent implements OnInit {
  survey : ISurvey = {
      id : 0,
      appointmentId : 0,
      done: false,
      surveyCategories : []
  };
  errorMessage : string  = '';

  constructor(private _surveyService : SurveyService, private _snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.survey.appointmentId = this._surveyService.appointmentId;
    this.showSurvey();
  }


  showSurvey() {
    this._surveyService.getSurvey(this.survey.appointmentId)
        .subscribe(survey => this.survey = survey,
                    error => this.errorMessage = <any>error); 
  }

  submit() {
    this._surveyService.addSurvey(this.survey)
        .subscribe(data => console.log('Success!', data),
                    error => console.log('Error!', error)) 
      console.log(this.survey);
      this._snackBar.open('Your survey has been submited.', 'Close', {duration: 3000}); 
    }

  validate() {
    var ok = true;
    this.survey.surveyCategories.forEach(category => { category.surveyQuestions.forEach(question => {
      if (question.grade == 0)
      {
        ok = false;
        /* break; */
      }
    });      
    });
    if (ok)
    {
      var button = document.getElementsByTagName("button")[0];
      button.title = "Submit your survey answers";
    }
    return ok;
  }
}
