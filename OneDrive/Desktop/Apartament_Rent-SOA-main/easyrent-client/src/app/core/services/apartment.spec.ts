import { TestBed } from '@angular/core/testing';

import { Apartment } from './apartment';

describe('Apartment', () => {
  let service: Apartment;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Apartment);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
