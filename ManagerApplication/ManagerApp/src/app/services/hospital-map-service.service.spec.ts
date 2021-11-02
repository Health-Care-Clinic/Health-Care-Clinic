import { TestBed } from '@angular/core/testing';

import { HospitalMapServiceService } from './hospital-map-service.service';

describe('HospitalMapServiceService', () => {
  let service: HospitalMapServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HospitalMapServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
