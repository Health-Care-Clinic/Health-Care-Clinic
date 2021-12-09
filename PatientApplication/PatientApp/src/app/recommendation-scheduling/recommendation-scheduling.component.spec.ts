import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RecommendationSchedulingComponent } from './recommendation-scheduling.component';

describe('RecommendationSchedulingComponent', () => {
  let component: RecommendationSchedulingComponent;
  let fixture: ComponentFixture<RecommendationSchedulingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RecommendationSchedulingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RecommendationSchedulingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
