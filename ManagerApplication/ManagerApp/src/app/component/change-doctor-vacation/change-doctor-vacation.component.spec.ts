import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChangeDoctorVacationComponent } from './change-doctor-vacation.component';

describe('ChangeDoctorVacationComponent', () => {
  let component: ChangeDoctorVacationComponent;
  let fixture: ComponentFixture<ChangeDoctorVacationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChangeDoctorVacationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ChangeDoctorVacationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
