import { HabilidadeDataService } from './../shared/habilidade-data.service';
import { Observable } from 'rxjs';
import { HabilidadeService } from './../shared/habilidade.service';
import { Habilidade } from './../shared/habilidade';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  habilidades: Observable<any>;

  constructor(private habilidadeService: HabilidadeService, private habilidadeDataService: HabilidadeDataService) { }

  ngOnInit() {
    this.habilidades = this.habilidadeService.getAll();
  }

  delete(key: string) {
     this.habilidadeService.delete(key);
  }

  edit(habilidade: Habilidade, key: string) {
     this.habilidadeDataService.changeHabilidade(habilidade, key);
  }

}
