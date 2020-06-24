import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BuscarPerfilComponent } from './buscar-perfil/buscar-perfil.component';
import { CadastroPerfilComponent } from './cadastro-perfil/cadastro-perfil.component';
import { CadastroOportunidadeComponent } from './cadastro-oportunidade/cadastro-oportunidade.component';


const routes: Routes = [
  { path: "buscar", component: BuscarPerfilComponent },
  { path: "perfil", component: CadastroPerfilComponent},
  { path: "oportunidade", component: CadastroOportunidadeComponent},
  { path: "", redirectTo: "/buscar", pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],


  exports: [RouterModule],

})
export class AppRoutingModule {}
