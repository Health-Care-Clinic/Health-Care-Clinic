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

  publishPromotion(id: number){
    this._promotionService.togglePublishPromotion(id).subscribe(res => {
      for(let p of this.promotions){
        if(p.id === id){
          p.posted = true;
        }
      }
    });
  }

  removePublishedPromotion(id: number){
    this._promotionService.togglePublishPromotion(id).subscribe(res => {
      for(let p of this.promotions){
        if(p.id === id){
          p.posted = false;
        }
      }
    });
  }
}
