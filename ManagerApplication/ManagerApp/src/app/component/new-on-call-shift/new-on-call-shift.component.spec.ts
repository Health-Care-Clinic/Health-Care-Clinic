import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewOnCallShiftComponent } from './new-on-call-shift.component';

describe('NewOnCallShiftComponent', () => {
  let component: NewOnCallShiftComponent;
  let fixture: ComponentFixture<NewOnCallShiftComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewOnCallShiftComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewOnCallShiftComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
