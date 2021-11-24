import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MedicineSpecificationsComponent } from './medicine-specifications.component';

describe('MedicineSpecificationsComponent', () => {
  let component: MedicineSpecificationsComponent;
  let fixture: ComponentFixture<MedicineSpecificationsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MedicineSpecificationsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MedicineSpecificationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
