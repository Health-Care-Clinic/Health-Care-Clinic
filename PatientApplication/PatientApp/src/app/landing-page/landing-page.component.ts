import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AppointmentService } from '../service/appointment.service';
import { FeedbackService } from '../service/feedback.service';
import { IFeedback } from '../service/IFeedback';
import { PharmacyPromotion } from './PharmacyPromotion';

@Component({
  selector: 'app-landing-page',
  templateUrl: './landing-page.component.html',
  styleUrls: ['./landing-page.component.css']
})
export class LandingPageComponent implements OnInit {
  slides = [
    {
      image: /* "../images/slide1.jpg" */
        "https://images.pexels.com/photos/3769151/pexels-photo-3769151.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260"
    },
    {
      image:
        "https://images.pexels.com/photos/127873/pexels-photo-127873.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260"
    },
    {
      image:
        "https://images.pexels.com/photos/2383010/pexels-photo-2383010.jpeg?auto=compress&cs=tinysrgb&dpr=3&h=750&w=1260"
    },
    {
      image:
        "https://images.pexels.com/photos/3985163/pexels-photo-3985163.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260"
    },
    {
      image:
        "https://images.pexels.com/photos/269077/pexels-photo-269077.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260"
    }
  ];

  feedbacks : IFeedback[] = [];
  errorMessage : string  = '';
  promotions: PharmacyPromotion[] = [];
  _images: any[] = [];

  constructor(public dialog: MatDialog, private _feedbackService : FeedbackService, private _appointmentService : AppointmentService) { 
  }

  ngOnInit(): void {
    this.refreshFeedback();
    this.getPromotions();
  }

  openFeedbackDialog(feedback: any): void {
    
  }

  refreshFeedback() {
    this._feedbackService.getPublishedFeedbacks()
        .subscribe(feedbacks => this.feedbacks = feedbacks,
                    error => this.errorMessage = <any>error);     
  }

  getPromotions() {
    this._appointmentService.getPromotions()
        .subscribe(data => {
                              this.promotions = data
                              this._images = []
                              for(let i=1; i <= this.promotions.length; i++)
                                this._images.push({path: '', width: 0, height: 0})
                              console.log(data)},
                    error => this.errorMessage = <any>error);  
  }
}
