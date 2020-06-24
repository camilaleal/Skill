import { Oportunidades } from './oportunidades';
import { Injectable } from '@angular/core';
import { AngularFireDatabase } from '@angular/fire/database';
import { map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class OportunidadesService {

  constructor(private db: AngularFireDatabase) { }

  insert(oportunidades: Oportunidades) {
    this.db.list('oportunidades').push(oportunidades)
      .then((result: any) => {
        console.log(result.key);
      });
  }

  update(oportunidades: Oportunidades, key: string) {
   return this.db.list('oportunidades').update(key, oportunidades)
      .catch((error: any) => {
        console.error(error);
      });
  }

   getAll() {
     return this.db.list('oportunidades')
       .snapshotChanges()
       .pipe(
          map(changes => {
          return changes.map(c => ({ key: c.payload.key, ...c.payload.val() }));
         })
       );
   }

  delete(key: string) {
    this.db.object(`oportunidades/${key}`).remove();
  }

//   search(habilidade: string){
//     return this.db.list('oportunidades', ref => ref.orderByChild('oportunidade').equalTo(oportunidade))
//       .snapshotChanges()
//       .pipe(
//         map(changes => {
//           console.log(changes);
//           return changes.map(c => ({ key: c.payload.key, ...c.payload.val() }));
//         })
//       );

  }

