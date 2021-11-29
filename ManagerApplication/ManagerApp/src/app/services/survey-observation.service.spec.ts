import { TestBed } from '@angular/core/testing';

import { SurveyObservationService } from './survey-observation.service';

describe('SurveyObservationService', () => {
  let service: SurveyObservationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SurveyObservationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
