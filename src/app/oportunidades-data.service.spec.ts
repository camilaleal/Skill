import { TestBed } from '@angular/core/testing';

import { OportunidadesDataService } from './oportunidades-data.service';

describe('OportunidadesDataService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: OportunidadesDataService = TestBed.get(OportunidadesDataService);
    expect(service).toBeTruthy();
  });
});
