import { Injectable } from '@angular/core';
import { AngularFireDatabase } from '@angular/fire/database';
import { Perfil } from './perfil';
import { map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class PerfilService {

  constructor(private db: AngularFireDatabase) { }

  insert(perfil: Perfil) {
    this.db.list('perfil').push(perfil)
      .then((result: any) => {
        console.log(result.key);
      });
  }

  update(perfil: Perfil, key: string) {
   return this.db.list('perfil').update(key, perfil)
      .catch((error: any) => {
        console.error(error);
      });
  }

  getAll() {
    return this.db.list('perfil')
      .snapshotChanges()
      .pipe(
        map(changes => {
          return changes.map(c => ({ key: c.payload.key, ...c.payload.val() }));
        })
      );
  }

  delete(key: string) {
    this.db.object(`perfil/${key}`).remove();
  }
}
