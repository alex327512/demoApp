import { TestBed } from '@angular/core/testing';

import { IncomingDataService } from './incoming-data.service';

describe('IncomingDataService', () => {
  let service: IncomingDataService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(IncomingDataService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
