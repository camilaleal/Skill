import { Oportunidades } from './oportunidades';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OportunidadesDataService {
  private oportunidadesSource = new BehaviorSubject({ oportunidades: null, key: '' });
  currentOportunidades = this.oportunidadesSource.asObservable();

  constructor() { }

  changeOportunidades(oportunidades: Oportunidades, key: string) {
    this.oportunidadesSource.next({ oportunidades, key });
  }
}
