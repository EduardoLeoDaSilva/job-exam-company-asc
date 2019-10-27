import { Materia } from "./materia.modelo";
import { Aluno } from "./aluno-modelo";

export class Resultado {
  resultadoId: number;
  aluno: Aluno;
  materia: Materia;
  NotaFinal: number;
  aprovado: boolean;
}
