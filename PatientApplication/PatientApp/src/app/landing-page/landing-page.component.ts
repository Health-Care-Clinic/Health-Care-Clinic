import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

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

  feedback = {
    user: "",
    content: ""
  }

  feedbacks = [
      {
        user: "Nadja",
        content: "adasdas"
      },
      {
        user: "Nadja",
        content: "adasdas"
      },
      {
        user: "Nadja",
        content: "adasdas"
      },
      {
        user: "Nadja",
        content: "adasdas"
      },
      {
        user: "Nadja",
        content: "adasdas"
      },
      {
        user: "Nadja",
        content: "adasdas"
      },
      {
        user: "Nadja",
        content: "adasdas"
      }
  ];

  constructor(public dialog: MatDialog) { 
  }

  ngOnInit(): void {
  }

  openFeedbackDialog(feedback: any): void {
    
  }
}
