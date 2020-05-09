import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filtroIdade'
})
export class FiltroIdadePipe implements PipeTransform {

  transform(perfil: any, args?: any): any {
    return perfil.filter(function(perfil){
      return perfil.idade == "marcax"
    });
  }

}
