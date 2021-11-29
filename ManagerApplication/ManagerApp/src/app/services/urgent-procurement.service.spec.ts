import { TestBed } from '@angular/core/testing';

import { UrgentProcurementService } from './urgent-procurement.service';

describe('UrgentProcurementService', () => {
  let service: UrgentProcurementService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UrgentProcurementService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
