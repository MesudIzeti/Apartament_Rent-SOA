import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LandlordProperties } from './landlord-properties';

describe('LandlordProperties', () => {
  let component: LandlordProperties;
  let fixture: ComponentFixture<LandlordProperties>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LandlordProperties],
    }).compileComponents();

    fixture = TestBed.createComponent(LandlordProperties);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
