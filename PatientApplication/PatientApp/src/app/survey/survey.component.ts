import { Component, OnInit } from '@angular/core';
import { ISurvey } from './survey';
import { ISurveyQuestion } from './survey-question';
import { ISurveyCategory } from './survey-category';
import { SurveyService } from './survey.service';

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
  /* questionTypeTitles : string[] = ["Doctor", "Medical stuff", "Hospital"] */

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
