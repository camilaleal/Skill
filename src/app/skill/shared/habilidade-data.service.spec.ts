import { TestBed } from '@angular/core/testing';

import { HabilidadeDataService } from './habilidade-data.service';

describe('HabilidadeDataService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: HabilidadeDataService = TestBed.get(HabilidadeDataService);
    expect(service).toBeTruthy();
  });
});
