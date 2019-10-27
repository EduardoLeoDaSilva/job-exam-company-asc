import { Prova } from "./prova-modelo";
import { Turma } from "./turma-modelo";
import { Resultado } from "./resultado-modelo";

export class Aluno {
  alunoId: number;
  nome: string;
  provas: Array<Prova>
  turma: Turma;
  resultados: Array<Resultado>;
}
