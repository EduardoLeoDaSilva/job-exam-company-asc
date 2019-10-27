import { Injectable, Inject } from '@angular/core'
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Observable } from 'rxjs'
import { Usuario } from '../modelos/usuario.modelo';


@Injectable({
  providedIn: "root"
})
export class UsuarioServico {

  private baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  public RealizarLogIn(usuario: Usuario): Observable<Usuario> {

    var body = {
      email: usuario.email,
      senha: usuario.senha
    }

    let headers = new HttpHeaders().set('content-type', 'application/json');

    return this.http.post<Usuario>(`${this.baseUrl}/api/usuario`, body, { headers });

  }
}
