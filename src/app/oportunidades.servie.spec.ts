import { TestBed } from '@angular/core/testing';

import { OportunidadesService } from './oportunidades.service';

describe('OportunidadesService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: OportunidadesService = TestBed.get(OportunidadesService);
    expect(service).toBeTruthy();
  });
});
