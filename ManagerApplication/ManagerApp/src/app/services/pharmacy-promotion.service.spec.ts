import { TestBed } from '@angular/core/testing';

import { PharmacyPromotionService } from './pharmacy-promotion.service';

describe('PharmacyPromotionService', () => {
  let service: PharmacyPromotionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PharmacyPromotionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
