import { TestBed, inject } from '@angular/core/testing';

import { ListingApiService } from './listing-api.service';

describe('ListingApiService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ListingApiService]
    });
  });

  it('should be created', inject([ListingApiService], (service: ListingApiService) => {
    expect(service).toBeTruthy();
  }));
});
