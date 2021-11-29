import { TestBed } from '@angular/core/testing';

import { ConsumptionReportService } from './consumption-report.service';

describe('ConsumptionReportService', () => {
  let service: ConsumptionReportService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ConsumptionReportService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
