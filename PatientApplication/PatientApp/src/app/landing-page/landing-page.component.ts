import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-landing-page',
  templateUrl: './landing-page.component.html',
  styleUrls: ['./landing-page.component.css']
})
export class LandingPageComponent implements OnInit {
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
