import { Inject, Injectable } from '@angular/core'
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Observable } from 'rxjs'
import { Usuario } from '../modelos/usuario.modelo';


@Injectable({
  providedIn: "root"
})
export class CadastroUsuarioServico {

  private baseURL: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseURL: string) {
    this.baseURL = baseURL;
  }

  public cadastrar(usuario: Usuario): Observable<string> {

    let headers = new HttpHeaders().set('content-type', 'application/json')

    var body = {
      nome: usuario.nome,
      email: usuario.email,
      senha: usuario.senha
    }

    return this.http.post<string>(`${this.baseURL}/api/usuario/cadastrar`, body, { headers });

  }


}
