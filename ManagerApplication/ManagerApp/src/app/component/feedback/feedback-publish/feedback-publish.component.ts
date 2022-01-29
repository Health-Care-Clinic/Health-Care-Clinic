import { Component, Input, OnChanges } from '@angular/core';
import { FeedbackService } from '../../../services/feedback.service';
import { IFeedback } from '../../../model/feedback/IFeedback';
import {MatSnackBar} from '@angular/material/snack-bar';

@Component({
  selector: 'app-feedback-publish',
  templateUrl: './feedback-publish.component.html',
  styleUrls: ['./feedback-publish.component.css']
})
export class FeedbackPublishComponent implements OnChanges {

  @Input() feedback!: IFeedback;
  feedbacks : IFeedback[] = [];
  errorMessage : string  = '';

  constructor(private _feedbackService : FeedbackService, private _snackBar: MatSnackBar) { }

  ngOnChanges(): void {
    //this.refreshFeedback();
  }

  publish(feedback: IFeedback){
    feedback.isPublished = true;
    this._snackBar.open('Feedback has been successfuly published!', 'Close', {duration: 5000});
    this.editFeedback();
  }

  unpublish(feedback: IFeedback){
    feedback.isPublished = false;
    this._snackBar.open('Feedback has been successfuly unpublished!', 'Close', {duration: 5000});
    this.editFeedback();
  }

  editFeedback() {
    this._feedbackService.editFeedback(this.feedback)
      .subscribe(data => {
        this.feedback.id = data.id
        console.log(data)
        this.refreshFeedback();
      })      
  }

  refreshFeedback() {
    this._feedbackService.getFeedbacks()
        .subscribe(feedbacks => this.feedbacks = feedbacks,
                    error => this.errorMessage = <any>error);     
  }
}
