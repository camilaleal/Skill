import { Tipo } from './../tipo.model';
import { Component, OnInit, Input } from '@angular/core';
import { Oportunidades } from './../oportunidades';
import { OportunidadesService } from '../oportunidades.service';
import { OportunidadesDataService } from '../Oportunidades-data.service';

@Component({
  selector: 'app-cadastro-oportunidade',
  templateUrl: './cadastro-oportunidade.component.html',
  styleUrls: ['./cadastro-oportunidade.component.css']
})
export class CadastroOportunidadeComponent implements OnInit {
  oportunidades: Oportunidades;
  tipos = [
    new Oportunidades('Emprego'),
    new Oportunidades('Consultor'),
    new Oportunidades('´Palestrante')
] 

  key = '';


 valor;


  constructor(
    private oportunidadesService: OportunidadesService,
    private oportunidadesDataService: OportunidadesDataService) { }

  ngOnInit() {
    this.oportunidades = new Oportunidades();
    this.oportunidadesDataService.currentOportunidades.subscribe(data => {
      if (data.oportunidades && data.key) {
        this.oportunidades = new Oportunidades();
        this.oportunidades.type_oportunidade = data.oportunidades.type_oportunidade;
        this.oportunidades.descricao = data.oportunidades.descricao;
        this.key = data.key;
      }
    });
  }

  onSubmit() {
    if (this.key) {
      this.oportunidadesService.update(this.oportunidades, this.key);
    } else {
      this.oportunidadesService.insert(this.oportunidades);
    }
    console.log("valor selecionado", this.valor);
    this.oportunidades = new Oportunidades();
  }


}