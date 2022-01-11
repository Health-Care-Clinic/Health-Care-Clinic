import { Component, OnInit } from '@angular/core';
import { ITender } from '../model/tender';
import { ITenderResponse } from '../model/tenderResponse';
import { ActivatedRoute, Router } from '@angular/router';
import { TenderingServiceService } from '../services/tendering-service.service';

@Component({
  selector: 'app-tender-offers',
  templateUrl: './tender-offers.component.html',
  styleUrls: ['./tender-offers.component.css']
})
export class TenderOffersComponent implements OnInit {

  public responses: ITenderResponse[] = [];
  public id: number = -1;
  constructor(private _tenderService: TenderingServiceService, private _route: ActivatedRoute, private _router: Router) { }

  ngOnInit(): void {
    this.id = +this._route.snapshot.paramMap.get('id');
    this._tenderService.getTenderResponses(this.id).subscribe(
      responses => { this.responses = responses;
    });
  }

  chooseOffer(id: number) {
    this._tenderService.chooseOffer(id).subscribe( response => {
      
    });
    this.openTendersComponent();
  }

  openTendersComponent(): void {
    this._router.navigate(['tenders']);
  }
}
