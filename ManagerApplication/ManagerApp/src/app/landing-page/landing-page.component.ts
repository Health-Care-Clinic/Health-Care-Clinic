import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { FeedbackService } from '../services/feedback.service';
import { IFeedback } from '../model/feedback/IFeedback';
import { PharmacyPromotionService } from '../services/pharmacy-promotion.service';
import { IPromotion } from '../model/promotion';

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
  promotions : IPromotion[] = [];
  errorMessage : string  = '';

  constructor(public dialog: MatDialog, private _feedbackService : FeedbackService, private _promotionService : PharmacyPromotionService) { 
  }

  ngOnInit(): void {
    //this.refreshFeedback();
    this.promotions = this._promotionService.getPostedPharmacyPromotions()
  }

  openFeedbackDialog(feedback: any): void {
    
  }

  refreshFeedback() {
    this._feedbackService.getPublishedFeedbacks()
        .subscribe(feedbacks => this.feedbacks = feedbacks,
                    error => this.errorMessage = <any>error);     
  }
}
