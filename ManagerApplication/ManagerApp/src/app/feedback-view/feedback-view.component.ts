import { Component, OnInit } from '@angular/core';
import { feedbacks } from '../feedbacks';

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
}
