import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Feedback } from '../feedback';
import { FeedbackService } from '../feedback.service';
import {MatSnackBar} from '@angular/material/snack-bar';
import { Router } from '@angular/router';


@Component({
  selector: 'feedback-form',
  templateUrl: './feedback-form.component.html',
  styleUrls: ['./feedback-form.component.css']
})

export class FeedbackFormComponent {

  feedbackModel: Feedback = new Feedback();

  constructor(private _feedbackService: FeedbackService, private router: Router, private _snackBar: MatSnackBar) {}

  submit(): void {
    this.feedbackModel.identity = JSON.parse(localStorage.getItem('id') || '{}');
  
    this._feedbackService.addFeedback(this.feedbackModel)
    .subscribe(
      data => console.log('Success!', data),
      error => console.log('Error!', error)
    ) 
    
    this.router.navigateByUrl('')

    this._snackBar.open('Your feedback has been submited.', 'Close', {duration: 3000});
    this.feedbackModel = new Feedback();
    }  
}
