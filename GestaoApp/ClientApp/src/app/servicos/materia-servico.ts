import { Inject, Injectable } from '@angular/core'
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Observable } from 'rxjs'
import { Materia } from '../modelos/materia.modelo';
import { Prova } from '../modelos/prova-modelo';


@Injectable({
  providedIn: "root"
})
export class MateriaServico {

  private baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  public cadastrarProduto(materia: Materia): Observable<Array<Materia>>{

    const headers = new HttpHeaders().set('content-type', 'application/json');

    var body = {
      nome: materia.nome,
      peso1: materia.peso1,
      peso2: materia.peso2,
      peso3: materia.peso3
    }

    return this.http.post<Array<Materia>>(`${this.baseUrl}/api/materia`, body, { headers });

  }

  public ObterMaterias() : Observable<Array<Materia>> {

    return this.http.get<Array<Materia>>(`${this.baseUrl}/api/materia`);
  }
}
