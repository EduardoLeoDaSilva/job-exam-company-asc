import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { LoginComponent } from './login/login-component';
import { UsuarioServico } from './servicos/usuario.servico';
import { MateriaCadastroComponent } from './cadastro/materia/materiaCadastro-component';
import { MateriaServico } from './servicos/materia-servico';
import { SimulacaoComponent } from './simulacao/simulacao-component';
import { SimulacaoServico } from './servicos/simulacao-servico';
import { TabelaExpandComponent } from './shared/tabelaExpand/tabelaExpand-component';
import { GuardaRotas } from './autorizacao/GuardaRotas';
import { CadastroUsuarioComponent } from './cadastro/usuario/cadastroUsuario-component';
import { CadastroUsuarioServico } from './servicos/cadastroUsuario-servico';
import { ListaAlunosComponent } from './lista-alunosTodos/listaAlunos-component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    LoginComponent,
    MateriaCadastroComponent,
    SimulacaoComponent,
    TabelaExpandComponent,
    CadastroUsuarioComponent,
    ListaAlunosComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: LoginComponent },
      { path: 'login', component: LoginComponent },
      { path: 'materia', component: MateriaCadastroComponent, canActivate: [GuardaRotas] },
      { path: 'simulacao', component: SimulacaoComponent, canActivate: [GuardaRotas]  },
      { path: 'cadastro', component: CadastroUsuarioComponent},
      { path: 'listaalunos', component: ListaAlunosComponent, canActivate: [GuardaRotas] },
    ])
  ],
  providers: [UsuarioServico, MateriaServico, SimulacaoServico, CadastroUsuarioServico],
  bootstrap: [AppComponent]
})
export class AppModule { }
