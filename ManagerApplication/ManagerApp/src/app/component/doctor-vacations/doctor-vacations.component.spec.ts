import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DoctorVacationsComponent } from './doctor-vacations.component';

describe('DoctorVacationsComponent', () => {
  let component: DoctorVacationsComponent;
  let fixture: ComponentFixture<DoctorVacationsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DoctorVacationsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DoctorVacationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
