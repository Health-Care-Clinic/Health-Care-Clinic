import { Component, Input, OnChanges } from '@angular/core';
import { FeedbackService } from '../../../services/feedback.service';
import { IFeedback } from '../../../model/feedback/IFeedback';

@Component({
  selector: 'app-feedback-publish',
  templateUrl: './feedback-publish.component.html',
  styleUrls: ['./feedback-publish.component.css']
})
export class FeedbackPublishComponent implements OnChanges {

  @Input() feedback!: IFeedback;
  feedbacks : IFeedback[] = [];
  errorMessage : string  = '';

  constructor(private _feedbackService : FeedbackService) { }

  ngOnChanges(): void {
    //this.refreshFeedback();
  }

  publish(feedback: IFeedback){
    feedback.isPublished = true;
    window.alert('Mišljenje pacijenta je objavljeno!');
    this.editFeedback();
  }

  unpublish(feedback: IFeedback){
    feedback.isPublished = false;
    window.alert('Mišljenje pacijenta je povuceno!');
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
