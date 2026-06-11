import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TenantBookings } from './tenant-bookings';

describe('TenantBookings', () => {
  let component: TenantBookings;
  let fixture: ComponentFixture<TenantBookings>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TenantBookings],
    }).compileComponents();

    fixture = TestBed.createComponent(TenantBookings);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
