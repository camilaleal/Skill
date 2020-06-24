import { Component, OnInit, Input } from '@angular/core';
import { Perfil } from '../perfil';
import { PerfilService } from '../perfil.service';
import { PerfilDataService } from '../perfil-data.service';



@Component({
  selector: 'app-cadastro-perfil',
  templateUrl: './cadastro-perfil.component.html',
  styleUrls: ['./cadastro-perfil.component.css']
})
export class CadastroPerfilComponent implements OnInit {
  perfil: Perfil;
  key = '';
  

  constructor(private perfilService: PerfilService, private perfilDataService: PerfilDataService) { }


 
  ngOnInit() {
    this.perfil = new Perfil();
    this.perfilDataService.currentPerfil.subscribe(data => {
      if (data.perfil && data.key) {
        this.perfil = new Perfil();
        this.perfil.nome = data.perfil.nome;
        this.perfil.sobrenome = data.perfil.sobrenome;
        this.perfil.profissao = data.perfil.profissao;
       // this.perfil.cidade = data.perfil.cidade;
        this.perfil.habilidade = data.perfil.habilidade;
        this.perfil.nivel = data.perfil.nivel;
        this.key = data.key;
      }
    });
  }

  onSubmit() {
    if (this.key) {
      this.perfilService.update(this.perfil, this.key);
    } else {
      this.perfilService.insert(this.perfil);
    }

    this.perfil = new Perfil();
  }

  }

