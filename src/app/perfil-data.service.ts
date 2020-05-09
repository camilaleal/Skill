import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Perfil } from './perfil';

@Injectable({
  providedIn: 'root'
})
export class PerfilDataService {
  private perfilSource = new BehaviorSubject({ perfil: null, key: '' });
  currentPerfil = this.perfilSource.asObservable();

  constructor() { }

  changePerfil(perfil: Perfil, key: string) {
    this.perfilSource.next({ perfil, key });
  }
}
