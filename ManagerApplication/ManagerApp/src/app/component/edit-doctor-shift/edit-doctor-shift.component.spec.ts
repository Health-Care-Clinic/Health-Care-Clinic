import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditDoctorShiftComponent } from './edit-doctor-shift.component';

describe('EditDoctorShiftComponent', () => {
  let component: EditDoctorShiftComponent;
  let fixture: ComponentFixture<EditDoctorShiftComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditDoctorShiftComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditDoctorShiftComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
