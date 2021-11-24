import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UrgentProcurementComponent } from './urgent-procurement.component';

describe('UrgentProcurementComponent', () => {
  let component: UrgentProcurementComponent;
  let fixture: ComponentFixture<UrgentProcurementComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UrgentProcurementComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UrgentProcurementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
