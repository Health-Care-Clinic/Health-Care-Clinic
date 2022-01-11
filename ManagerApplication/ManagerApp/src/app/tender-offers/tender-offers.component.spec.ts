import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TenderOffersComponent } from './tender-offers.component';

describe('TenderOffersComponent', () => {
  let component: TenderOffersComponent;
  let fixture: ComponentFixture<TenderOffersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TenderOffersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TenderOffersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
