import { TestBed, inject } from '@angular/core/testing';

import { ExcursionSightService } from './excursion-sight.service';

describe('ExcursionSightService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ExcursionSightService]
    });
  });

  it('should be created', inject([ExcursionSightService], (service: ExcursionSightService) => {
    expect(service).toBeTruthy();
  }));
});
