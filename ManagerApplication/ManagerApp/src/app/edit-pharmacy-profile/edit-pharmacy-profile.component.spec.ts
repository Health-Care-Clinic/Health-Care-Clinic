import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditPharmacyProfileComponent } from './edit-pharmacy-profile.component';

describe('EditPharmacyProfileComponent', () => {
  let component: EditPharmacyProfileComponent;
  let fixture: ComponentFixture<EditPharmacyProfileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditPharmacyProfileComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditPharmacyProfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
