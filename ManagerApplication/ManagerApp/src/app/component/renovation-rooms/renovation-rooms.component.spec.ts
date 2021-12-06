import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RenovationRoomsComponent } from './renovation-rooms.component';

describe('RenovationRoomsComponent', () => {
  let component: RenovationRoomsComponent;
  let fixture: ComponentFixture<RenovationRoomsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RenovationRoomsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RenovationRoomsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});