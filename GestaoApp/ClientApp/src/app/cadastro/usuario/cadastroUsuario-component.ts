import { Component, OnInit } from '@angular/core'
import { Usuario } from '../../modelos/usuario.modelo';
import { CadastroUsuarioServico } from '../../servicos/cadastroUsuario-servico';
import { Router } from '@angular/router';


@Component({
  selector: 'cadastro-usuario',
  templateUrl: './cadastroUsuario-component.html',
  styleUrls: ['./cadastroUsuario-component.css']
})
export class CadastroUsuarioComponent implements OnInit {
    

  public usuario: Usuario;
  public msgSucesso: string;
  public msgFalha: string;
  public spinnerAtivo: boolean = false;

  constructor(private usuarioServico: CadastroUsuarioServico, private router : Router) {

  }


  ngOnInit(): void {
    this.usuario = new Usuario();
    var autenticado = sessionStorage.getItem("autenticado");
    if (autenticado == '1') {
      this.router.navigate(['/materia'])
    }
  }

  cadastrar() {
    this.spinnerAtivo = true;
    this.usuarioServico.cadastrar(this.usuario).subscribe(
      data => {
        this.msgSucesso = data;
        console.log(data);
        this.spinnerAtivo = false;

        this.router.navigate(['/login']);
      },
      err => {
        this.msgFalha = err.error;
        console.log(err);

        this.spinnerAtivo = false;

      }
    );
  }

}
