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
        this.perfil.idade = data.perfil.idade;
        this.perfil.apresentacao = data.perfil.apresentacao;
        this.perfil.habilidade = data.perfil.habilidade;
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

