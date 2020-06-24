import { TestBed } from '@angular/core/testing';

import { HabilidadeService } from './habilidade.service';

describe('HabilidadeService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: HabilidadeService = TestBed.get(HabilidadeService);
    expect(service).toBeTruthy();
  });
});
