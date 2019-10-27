import {  Injectable } from '@angular/core'
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router'

@Injectable({
  providedIn: "root"
})
export class GuardaRotas implements CanActivate {

  constructor(public router: Router) {

  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    let autenticado = sessionStorage.getItem('autenticado');
    if (autenticado == '1') {
      return true;
    }
    return false;
  }

}
