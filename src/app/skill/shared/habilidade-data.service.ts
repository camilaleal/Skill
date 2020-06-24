import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Habilidade } from './habilidade';

@Injectable({
  providedIn: 'root'
})
export class HabilidadeDataService {
  private habilidadeSource = new BehaviorSubject({ habilidade: null, key: '' });
  currentHabilidade = this.habilidadeSource.asObservable();

  constructor() { }

  changeHabilidade(habilidade: Habilidade, key: string) {
    this.habilidadeSource.next({ habilidade: habilidade, key: key});
  }

  }

