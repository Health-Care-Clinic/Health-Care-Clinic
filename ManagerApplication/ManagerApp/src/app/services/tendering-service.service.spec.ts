import { TestBed } from '@angular/core/testing';

import { TenderingServiceService } from './tendering-service.service';

describe('TenderingServiceService', () => {
  let service: TenderingServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TenderingServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
