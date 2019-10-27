import { Materia } from "./materia.modelo";
import { Aluno } from "./aluno-modelo";

export class Prova {
  nome: string;
  peso: number;
  nota: number;
  materia: Materia;
  aluno: Aluno;


  constructor(nome: string, peso: number) {
    this.nome = nome;
    this.peso = peso;
  }
}
