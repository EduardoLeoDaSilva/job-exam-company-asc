import { Component } from '@angular/core'
import { SimulacaoServico } from '../servicos/simulacao-servico';
import { Turma } from '../modelos/turma-modelo';

@Component({
  selector: 'lista-alunos',
  templateUrl: './listaAlunos-component.html',
  styleUrls: ['./listaAlunos-component.css']
})
export class ListaAlunosComponent  {
    
   
  public response: Array<Turma>;
  public msg: string;


  constructor(public simulacaoServico: SimulacaoServico) {
    this.simulacaoServico.ObterTodasTurmas().subscribe(
      data => {

        this.response = data;
        if (this.response.length == 0|| this.response == undefined || this.response == null) {
          this.msg = "Não há dados no sistema";
        }
        console.log(this.response);
      },
      err => {
        this.msg = "Erro: " + err.error
      }
    );
  }

 



  
}
