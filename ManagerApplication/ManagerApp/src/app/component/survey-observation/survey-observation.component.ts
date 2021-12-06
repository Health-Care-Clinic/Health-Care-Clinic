import { Component, OnInit } from '@angular/core';

import { ISurveyStatistics } from '../../model/survey-observation/survey-statistics';
import { SurveyObservationService } from '../../services/survey-observation.service';

@Component({
  selector: 'app-survey-observation',
  templateUrl: './survey-observation.component.html',
  styleUrls: ['./survey-observation.component.css']
})
export class SurveyObservationComponent implements OnInit {
  surveyStatistics : ISurveyStatistics = {
    surveyCategoriesStatistics : []
};
  
  errorMessage : string  = '';
  
  constructor(private _surveyService : SurveyObservationService) { }
  
  ngOnInit(): void {
    this.showCurrentDateAndTimeInHeading();
    this.showSurveyStatistics();
  }

  // Reference: https://stackoverflow.com/questions/10211145/getting-current-date-and-time-in-javascript
  showCurrentDateAndTimeInHeading() {
    var heading = document.getElementsByTagName("h1")[0];

    var currentDateAndTime = new Date();
    var formattedCurrentDateAndTimeAsString = " " + currentDateAndTime.getDate() + "."
                + (currentDateAndTime.getMonth() + 1)  + "." 
                + currentDateAndTime.getFullYear() + ". "  
                + currentDateAndTime.getHours() + ":"  
                + currentDateAndTime.getMinutes();

    heading.textContent += formattedCurrentDateAndTimeAsString;
  }

  showSurveyStatistics() {
    this._surveyService.getSurveyStatistics()
        .subscribe(surveyStatistics => this.surveyStatistics = surveyStatistics,
                  error => this.errorMessage = <any>error); 
  }

  validate() {
    var ok = true;
    this.surveyStatistics.surveyCategoriesStatistics.forEach(category => 
      { category.surveyQuestionsStatistics.forEach(question => {
        if (question.averageGrade < 0)
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
