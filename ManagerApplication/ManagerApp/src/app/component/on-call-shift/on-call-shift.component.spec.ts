import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OnCallShiftComponent } from './on-call-shift.component';

describe('OnCallShiftComponent', () => {
  let component: OnCallShiftComponent;
  let fixture: ComponentFixture<OnCallShiftComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OnCallShiftComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OnCallShiftComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
