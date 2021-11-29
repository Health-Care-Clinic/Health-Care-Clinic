import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PharmacyPromotionsComponent } from './pharmacy-promotions.component';

describe('PharmacyPromotionsComponent', () => {
  let component: PharmacyPromotionsComponent;
  let fixture: ComponentFixture<PharmacyPromotionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PharmacyPromotionsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PharmacyPromotionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
