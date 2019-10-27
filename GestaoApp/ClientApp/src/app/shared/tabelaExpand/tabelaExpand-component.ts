import { Component, Input, ElementRef,Renderer2 } from '@angular/core'
import { element } from '@angular/core/src/render3/instructions';
import { Aluno } from '../../modelos/aluno-modelo';

@Component({
  selector: "tabela-expand",
  templateUrl: "./tabelaExpand-component.html",
  styleUrls: ["./tabelaExpand-component.css"]
})
export class TabelaExpandComponent {
  public toggleExpandir: string
  @Input() dadosTabela: Array<Aluno>;
  constructor(public rd: Renderer2) {
    console.log(this.dadosTabela);
  }

  expandir(elemento: HTMLElement) {
    let nomeClass = elemento.className;
    if (nomeClass == 'collapse show') {
      this.rd.removeClass(elemento, 'show');
    } else {
      this.rd.addClass(elemento, 'show');

    }   
  }

  
}
