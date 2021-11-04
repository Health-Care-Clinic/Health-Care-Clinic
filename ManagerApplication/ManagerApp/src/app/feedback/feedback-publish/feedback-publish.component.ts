import { Component, Input, OnChanges } from '@angular/core';
import { FeedbackService } from '../feedback.service';
import { IFeedback } from '../IFeedback';

@Component({
  selector: 'app-feedback-publish',
  templateUrl: './feedback-publish.component.html',
  styleUrls: ['./feedback-publish.component.css']
})
export class FeedbackPublishComponent implements OnChanges {

  @Input() feedback!: IFeedback;
  //@Output() publish = new EventEmitter();
  feedbacks : IFeedback[] = [];
  errorMessage : string  = '';

  constructor(private _feedbackService : FeedbackService) { }

  ngOnChanges(): void {
    //this.refreshFeedback();
  }

  publish(feedback: IFeedback){
    feedback.isPublished = true;
    window.alert('Mišljenje pacijenta je objavljeno!');
    this.addFeedback();
  }

  
  addFeedback() {
    this._feedbackService.addFeedback(this.feedback)
      .subscribe(data => {
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
