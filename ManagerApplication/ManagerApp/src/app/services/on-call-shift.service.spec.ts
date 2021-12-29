import { TestBed } from '@angular/core/testing';

import { OnCallShiftService } from './on-call-shift.service';

describe('OnCallShiftService', () => {
  let service: OnCallShiftService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OnCallShiftService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
