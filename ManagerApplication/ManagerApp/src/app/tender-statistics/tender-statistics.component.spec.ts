import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TenderStatisticsComponent } from './tender-statistics.component';

describe('TenderStatisticsComponent', () => {
  let component: TenderStatisticsComponent;
  let fixture: ComponentFixture<TenderStatisticsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TenderStatisticsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TenderStatisticsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
