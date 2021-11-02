import { Component, OnInit } from '@angular/core';
import { feedbacks } from '../feedbacks';
import { Feedback } from '../feedbacks';

@Component({
  selector: 'app-feedback-view',
  templateUrl: './feedback-view.component.html',
  styleUrls: ['./feedback-view.component.css']
})
export class FeedbackViewComponent implements OnInit {
  feedbacks = feedbacks;

  constructor() { }

  ngOnInit(): void {
  }

  onPublish(feedback: Feedback){
    feedback.isPublished = true;
    window.alert('Mišljenje pacijenta je objavljeno!')
  }
}
