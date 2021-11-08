import { Component, OnInit } from '@angular/core';
import { FeedbackService } from '../../../services/feedback.service';
import { IFeedback } from '../../../model/feedback/IFeedback';


@Component({
  selector: 'app-feedback-view',
  templateUrl: './feedback-view.component.html',
  styleUrls: ['./feedback-view.component.css']
})
export class FeedbackViewComponent implements OnInit {
  feedbacks : IFeedback[] = [];
  errorMessage : string  = '';
  displayedColumns: string[] = ['identity', 'date', 'text', 'publish'];

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
