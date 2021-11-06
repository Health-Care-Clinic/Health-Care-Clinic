import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Feedback } from './feedback';
import { FeedbackService } from './feedback.service';

@Component({
  selector: 'feedback-form',
  templateUrl: './feedback-form.component.html',
  styleUrls: ['./feedback-form.component.css']
})

export class FeedbackForm {

  feedbackModel: Feedback = new Feedback();

  constructor(private _feedbackService: FeedbackService) {}

  submit(): void {

    /**this._feedbackService.generate(this.feedbackModel)
    .subscribe(
      data => console.log('Success!', data),
      error => console.log('Error!', error)
    ) **/

    console.log(this.feedbackModel);
    window.alert('Your feedback has been submited.');
    this.feedbackModel = new Feedback();
  }

  
}
