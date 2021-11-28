import { TestBed } from '@angular/core/testing';

import { MedicineSpecificationService } from './medicine-specification.service';

describe('MedicineSpecificationService', () => {
  let service: MedicineSpecificationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MedicineSpecificationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
