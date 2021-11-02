import { Component, OnInit, Input, Output, EventEmitter  } from '@angular/core';
import { Feedback } from '../feedbacks';

@Component({
  selector: 'app-feedback-publish',
  templateUrl: './feedback-publish.component.html',
  styleUrls: ['./feedback-publish.component.css']
})
export class FeedbackPublishComponent implements OnInit {

  @Input() feedback!: Feedback;
  @Output() publish = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

}
