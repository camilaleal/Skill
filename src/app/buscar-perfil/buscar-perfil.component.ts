import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { Perfil } from '../perfil';
import { PerfilService } from '../perfil.service';
import { PerfilDataService } from '../perfil-data.service';
import { Observable } from 'rxjs';
import { MatTableDataSource } from '@angular/material';




@Component({
  selector: 'app-buscar-perfil',
  templateUrl: './buscar-perfil.component.html',
  styleUrls: ['./buscar-perfil.component.css']
})
export class BuscarPerfilComponent implements OnInit {
  displayedColumns: string[] = ['nome', 'idade', 'apresentacao', 'habilidade', 'Editar', 'Deletar'];
  perfil: Observable<any>;
  public dataSource = new MatTableDataSource<Perfil>();
  nome: string;


  constructor(private perfilService: PerfilService, private perfilDataService: PerfilDataService) {
  }


  ngOnInit() {
    this.perfil = this.perfilService.getAll();
  }

  Search() {
    console.log(this.nome);
   // this.dataSource.filter = value.trim().toLocaleLowerCase();
  }
  
  delete(key: string) {
    this.perfilService.delete(key);
  }

  edit(perfil: Perfil, key: string) {
    this.perfilDataService.changePerfil(perfil, key);
  }
}
