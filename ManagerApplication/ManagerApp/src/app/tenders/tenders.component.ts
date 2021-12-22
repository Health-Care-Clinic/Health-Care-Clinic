import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-tenders',
  templateUrl: './tenders.component.html',
  styleUrls: ['./tenders.component.css']
})
export class TendersComponent implements OnInit {

  constructor(private _router: Router) { }

  ngOnInit(): void {
  }

  openCreateTenderComponent(): void {
    this._router.navigate(['create-tender']);
  }

}
