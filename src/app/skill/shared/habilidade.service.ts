import { AngularFireDatabase } from '@angular/fire/database';
import { Injectable } from '@angular/core';
import { Habilidade } from './habilidade';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class HabilidadeService {

  constructor(private db: AngularFireDatabase) { }

insert(habilidade: Habilidade) {
  this.db.list('habilidade').push(habilidade)
  .then((result: any) => {
    console.log(result.key);
  });

}

update(habilidade: Habilidade, key: string) {
  this.db.list('habilidade').update(key, habilidade)
  .catch((error: any) => {
    console.error(error);
  });
}

getAll() {
  return this.db.list('habilidade')
  .snapshotChanges()
  .pipe(
    map(changes => {
      return changes.map(c => ({ key: c.payload.key, ...c.payload.val() }));
    })

    );
}

delete(key: string) {
  this.db.object(`habilidade/${key}`).remove();
}

}

