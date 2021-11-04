import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FeedbackPublishComponent } from './feedback-publish.component';

describe('FeedbackPublishComponent', () => {
  let component: FeedbackPublishComponent;
  let fixture: ComponentFixture<FeedbackPublishComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FeedbackPublishComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FeedbackPublishComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
