import { TestBed } from '@angular/core/testing';

import { PerfilDataService } from './perfil-data.service';

describe('PerfilDataService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PerfilDataService = TestBed.get(PerfilDataService);
    expect(service).toBeTruthy();
  });
});
