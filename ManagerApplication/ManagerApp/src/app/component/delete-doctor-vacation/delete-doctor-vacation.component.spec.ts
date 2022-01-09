import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteDoctorVacationComponent } from './delete-doctor-vacation.component';

describe('DeleteDoctorVacationComponent', () => {
  let component: DeleteDoctorVacationComponent;
  let fixture: ComponentFixture<DeleteDoctorVacationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeleteDoctorVacationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeleteDoctorVacationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
