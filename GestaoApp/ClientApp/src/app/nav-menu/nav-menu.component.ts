import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent{

  isExpanded = false;
  public autenticado: boolean = false;


  constructor(private router: Router) {

  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  usuarioLogado(): boolean {
    var sessionItem = sessionStorage.getItem('autenticado');
    if (sessionItem == '1') {
      this.autenticado = true;
      return true;
    } else {
      this.autenticado = false;
      return false;
    }
  }

  sair() {
    sessionStorage.setItem('autenticado', '0')
    this.autenticado = false;
    this.router.navigate(['/login']);
  }
}
