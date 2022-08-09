import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PharmacyTenderStatisticsComponent } from './pharmacy-tender-statistics.component';

describe('PharmacyTenderStatisticsComponent', () => {
  let component: PharmacyTenderStatisticsComponent;
  let fixture: ComponentFixture<PharmacyTenderStatisticsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PharmacyTenderStatisticsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PharmacyTenderStatisticsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
