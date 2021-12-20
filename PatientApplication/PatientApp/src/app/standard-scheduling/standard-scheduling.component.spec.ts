import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StandardSchedulingComponent } from './standard-scheduling.component';

describe('StandardSchedulingComponent', () => {
  let component: StandardSchedulingComponent;
  let fixture: ComponentFixture<StandardSchedulingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StandardSchedulingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StandardSchedulingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
