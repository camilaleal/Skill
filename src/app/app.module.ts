import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { BuscarPerfilComponent } from './buscar-perfil/buscar-perfil.component';
import { AppRoutingModule } from './app-routing.module';
import { environment } from '../environments/environment';
import { AngularFireModule } from '@angular/fire';
import { AngularFireDatabaseModule } from '@angular/fire/database';
import { CadastroPerfilComponent } from './cadastro-perfil/cadastro-perfil.component';

import {MatButtonModule} from '@angular/material/button';
import {MatInputModule} from '@angular/material/input';
import {MatTableModule} from '@angular/material/table';
import { FiltroIdadePipe } from './filtro-idade.pipe';
import { MatFormFieldModule } from '@angular/material';




@NgModule({
  declarations: [
    AppComponent,
    BuscarPerfilComponent,
    CadastroPerfilComponent,
    FiltroIdadePipe
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    AngularFireModule.initializeApp(environment.firebase),
    AngularFireDatabaseModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatInputModule,
    MatTableModule,
    MatFormFieldModule,
  ],


  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
