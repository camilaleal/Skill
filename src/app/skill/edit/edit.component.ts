import { Component, OnInit } from '@angular/core';
import { Habilidade } from './../shared/habilidade';
import { HabilidadeService } from './../shared/habilidade.service';
import { HabilidadeDataService } from './../shared/habilidade-data.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  habilidade: Habilidade
  key: string = '';

  constructor(private habilidadeService: HabilidadeService, private habilidadeDataService: HabilidadeDataService) { }

  ngOnInit() {
    this.habilidade = new Habilidade();
    this.habilidadeDataService.currentHabilidade.subscribe(data => {
      if (data.habilidade && data.key) {
        this.habilidade = new Habilidade();
        this.habilidade.habilidade = data.habilidade.habilidade;
        this.habilidade.nivel = data.habilidade.nivel;
        this.key = data.key;
      }
    })
  }

  onSubmit() {
    if (this.key) {
      this.habilidadeService.update(this.habilidade, this.key);
    } else {
      this.habilidadeService.insert(this.habilidade);
    }

    this.habilidade= new Habilidade();
  }

}
