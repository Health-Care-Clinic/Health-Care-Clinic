import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SurveyObservationComponent } from './survey-observation.component';

describe('SurveyObservationComponent', () => {
  let component: SurveyObservationComponent;
  let fixture: ComponentFixture<SurveyObservationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SurveyObservationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SurveyObservationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
