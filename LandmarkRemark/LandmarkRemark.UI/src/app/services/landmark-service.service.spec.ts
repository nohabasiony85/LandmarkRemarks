import { TestBed, inject } from '@angular/core/testing';

import { LandmarkService } from './landmark-service.service';

describe('LandmarkServiceService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LandmarkService]
    });
  });

  it('should ...', inject([LandmarkService], (service: LandmarkService) => {
    expect(service).toBeTruthy();
  }));
});
