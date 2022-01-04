import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddingShiftComponent } from './adding-shift.component';

describe('AddingShiftComponent', () => {
  let component: AddingShiftComponent;
  let fixture: ComponentFixture<AddingShiftComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddingShiftComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddingShiftComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
