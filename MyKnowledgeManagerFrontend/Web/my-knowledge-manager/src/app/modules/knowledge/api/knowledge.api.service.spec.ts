import { TestBed } from '@angular/core/testing';

import { KnowledgeApiService } from './knowledge.api.service';

describe('KnowledgeApiService', () => {
  let service: KnowledgeApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(KnowledgeApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
