import { Component, OnInit } from '@angular/core';
import { MatExpansionModule } from '@angular/material/expansion';
import { IPromotion } from '../model/promotion';
import { PharmacyPromotionService } from '../services/pharmacy-promotion.service';

@Component({
  selector: 'app-pharmacy-promotions',
  templateUrl: './pharmacy-promotions.component.html',
  styleUrls: ['./pharmacy-promotions.component.css']
})
export class PharmacyPromotionsComponent implements OnInit {

  
  promotions : IPromotion[] = [];
  constructor(private _promotionService : PharmacyPromotionService) { 
    
  }

  ngOnInit(): void {
    this._promotionService.getAllPromotions().subscribe(
      promotions => this.promotions = promotions
      );
  }

  isExpired(end: Date): boolean {
    return end < new Date();
  }


}
