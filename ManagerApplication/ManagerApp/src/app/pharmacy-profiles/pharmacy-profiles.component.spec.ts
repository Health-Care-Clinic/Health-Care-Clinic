import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PharmacyProfilesComponent } from './pharmacy-profiles.component';

describe('PharmacyProfilesComponent', () => {
  let component: PharmacyProfilesComponent;
  let fixture: ComponentFixture<PharmacyProfilesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PharmacyProfilesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PharmacyProfilesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
