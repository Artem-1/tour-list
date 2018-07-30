import { TestBed, inject } from '@angular/core/testing';

import { ExcursionService } from './excursion.service';

describe('ExcursionService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ExcursionService]
    });
  });

  it('should be created', inject([ExcursionService], (service: ExcursionService) => {
    expect(service).toBeTruthy();
  }));
});
