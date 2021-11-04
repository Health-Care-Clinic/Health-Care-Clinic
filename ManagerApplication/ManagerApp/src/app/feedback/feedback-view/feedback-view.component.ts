import { Component, OnInit } from '@angular/core';
import { FeedbackService } from '../feedback.service';
import { feedbacks, IFeedback } from '../IFeedback';


@Component({
  selector: 'app-feedback-view',
  templateUrl: './feedback-view.component.html',
  styleUrls: ['./feedback-view.component.css']
})
export class FeedbackViewComponent implements OnInit {
  feedbacks : IFeedback[] = [];
  //feedbacks= feedbacks;
  errorMessage : string  = '';

  constructor(private _feedbackService : FeedbackService) { }

  ngOnInit(): void {
    this.refreshFeedback();
  }

  refreshFeedback() {
    this._feedbackService.getFeedbacks()
        .subscribe(feedbacks => this.feedbacks = feedbacks,
                    error => this.errorMessage = <any>error);     
  }
}
