import { Component, OnInit,ViewChild, ElementRef } from '@angular/core'
import { Usuario } from '../modelos/usuario.modelo';
import { UsuarioServico } from '../servicos/usuario.servico';
import { Router } from '@angular/router'
@Component({
  selector: 'app-login',
  templateUrl: './login-component.html',
  styleUrls: ['./login-component.css']
})
export class LoginComponent implements OnInit {


  public usuario: Usuario;
  public mensagemErroRequisicao: string;
  public spinnerAtivado: boolean;
  constructor(private usuarioServico: UsuarioServico, private router: Router) {

  }

  ngOnInit(): void {
    this.usuario = new Usuario();
    this.spinnerAtivado = false;
    var autenticado = sessionStorage.getItem('autenticado');
    if (autenticado == '1') {
      this.router.navigate(['/materia']);
    }
  }

  entrar(emailValid: boolean, senhaValid: boolean): void {
    if (emailValid && senhaValid) {
    this.spinnerAtivado = true;
      this.usuarioServico.RealizarLogIn(this.usuario).subscribe(
        data => {
          sessionStorage.setItem('autenticado', '1');
          this.spinnerAtivado = false;
          this.mensagemErroRequisicao = '';
          this.router.navigate(['/materia']);
          //fazer agr a pagina de cadastro materia
        },
        err => {
          this.mensagemErroRequisicao = err.error;
          this.spinnerAtivado = false;

        },
      );
    }
  }



}
