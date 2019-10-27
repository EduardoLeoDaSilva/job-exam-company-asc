import { Component } from '@angular/core'
import { SimulacaoServico } from '../servicos/simulacao-servico';
import { Aluno } from '../modelos/aluno-modelo';
import { Turma } from '../modelos/turma-modelo';



@Component({
  selector: 'app-simulacao',
  templateUrl: './simulacao-component.html',
  styleUrls: ['./simulacao-component.css']
})
export class SimulacaoComponent {

  public turmas: number;
  public alunos: number;
  public response: Array<Turma>;
  public carregando: boolean = false;

  constructor(public simulacaoServico: SimulacaoServico) {

  }

  simular(): void {
    this.carregando = true;

    this.simulacaoServico.Simular(this.turmas, this.alunos).subscribe(
      data => {
        this.response = data;
        console.log(this.response);
        this.carregando = false;

      },
      err => {
        alert(err.error)
        this.carregando = false;

      }
    );

  }

}
