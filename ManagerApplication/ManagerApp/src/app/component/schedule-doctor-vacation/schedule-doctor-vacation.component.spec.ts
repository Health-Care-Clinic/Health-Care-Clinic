import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ScheduleDoctorVacationComponent } from './schedule-doctor-vacation.component';

describe('ScheduleDoctorVacationComponent', () => {
  let component: ScheduleDoctorVacationComponent;
  let fixture: ComponentFixture<ScheduleDoctorVacationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ScheduleDoctorVacationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ScheduleDoctorVacationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
