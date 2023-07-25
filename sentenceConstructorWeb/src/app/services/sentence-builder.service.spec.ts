import { TestBed } from '@angular/core/testing';

import { SentenceBuilderService } from './sentence-builder.service';

describe('SentenceBuilderService', () => {
  let service: SentenceBuilderService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SentenceBuilderService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
