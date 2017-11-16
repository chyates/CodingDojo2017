import { TestBed, inject } from '@angular/core/testing';

import { GhScoreService } from './gh-score.service';

describe('GhScoreService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [GhScoreService]
    });
  });

  it('should be created', inject([GhScoreService], (service: GhScoreService) => {
    expect(service).toBeTruthy();
  }));
});
