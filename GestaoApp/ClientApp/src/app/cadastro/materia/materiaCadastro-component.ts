import { Component, OnInit } from '@angular/core'
import { Materia } from '../../modelos/materia.modelo';
import { Prova } from '../../modelos/prova-modelo';
import { MateriaServico } from '../../servicos/materia-servico';


@Component({
  selector: 'cadastro-materia',
  templateUrl: './materiaCadastro-component.html',
  styleUrls: ['./materiaCadastro-component.css'],
})
export class MateriaCadastroComponent implements OnInit {
  public materia: Materia;
  public mensagemSucesso: string;
  public mensagemFalha: string;
  public materiasReponse: Array<Materia>
  constructor(public materiaServico: MateriaServico) {

  }


    ngOnInit(): void {
      this.materia = new Materia();
      this.obterMaterias();

  }

  cadastrar(): void {
   

    this.materiaServico.cadastrarProduto(this.materia).subscribe(
      data => {
        this.mensagemSucesso = "Matéria cadastrada";
        this.materiasReponse = data;
        console.log(this.materiasReponse);
      this.materia = new Materia();

        

      },
      err => {
        this.mensagemFalha = err.error;
      },
    )
  }

  public obterMaterias() {
    this.materiaServico.ObterMaterias().subscribe(
      data => {
        this.materiasReponse = data;
        console.log(this.materiasReponse)
      },
      err => {
        console.log(err.error)
      }
    )
  }

}
