import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Medicine } from '../model/medicine';
import { ITender } from '../model/tender';

@Component({
  selector: 'app-tenders',
  templateUrl: './tenders.component.html',
  styleUrls: ['./tenders.component.css']
})
export class TendersComponent implements OnInit {

  public tenders: ITender[] = [];

  constructor(private _router: Router) { }

  ngOnInit(): void {
    
    let date = new Date();
    let medicines1: Medicine[] = [{"name": "brufen", "quantity": 500}, {"name": "aspirin", "quantity": 800}, {"name": "analgin", "quantity": 350}];
    let medicines2: Medicine[] = [{"name": "bromazepan", "quantity": 500}, {"name": "ranisan", "quantity": 1200}, {"name": "rakutan", "quantity": 480}, {"name": "paracetamol", "quantity": 900}];
    this.tenders = [
        {
          "id": 0,
          "description": "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
          "startDate": date,
          "endDate": date,
          "isOpen": true, 
          "isWinningBidChosen": false,
          "medicines": medicines1,
          "price": 0, 
          "offersNumber": 0,
        },
        {
          "id": 1,
          "description": "Incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
          "startDate": date,
          "endDate": date,
          "isOpen": false,
          "isWinningBidChosen": false,
          "medicines": medicines2,
          "price": 0, 
          "offersNumber": 2,
        }, 
        {
          "id": 2,
          "description": "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
          "startDate": date,
          "endDate": date,
          "isOpen": closed, 
          "isWinningBidChosen": false,
          "medicines": medicines1,
          "price": 0, 
          "offersNumber": 5,
        },
      ];
  }

  openCreateTenderComponent(): void {
    this._router.navigate(['create-tender']);
  }

}
