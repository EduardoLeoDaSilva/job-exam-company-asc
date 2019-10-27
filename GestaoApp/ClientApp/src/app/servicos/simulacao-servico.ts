import { Inject, Injectable } from '@angular/core'
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Observable } from 'rxjs'
import { Turma } from '../modelos/turma-modelo';
import { Aluno } from '../modelos/aluno-modelo';


@Injectable({
  providedIn: "root"
})
export class SimulacaoServico {

  private baseUrl: string;

  constructor(public http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  public Simular(turmas: number, alunos: number): Observable<Array<Turma>> {

    let headers = new HttpHeaders().set("content-type", "application/json");

    var body = {
      turmas: turmas,
      alunos: alunos
    }

    return this.http.post<Array<Turma>>(`${this.baseUrl}/api/simulacao`, body, { headers });

  }

  public ObterTodasTurmas(): Observable<Array<Turma>> {
    let headers = new HttpHeaders().set("content-type", "application/json");

    return this.http.get<Array<Turma>>(`${this.baseUrl}/api/simulacao/GetTodasTurmasRelacionadas`, { headers });
  }

}
