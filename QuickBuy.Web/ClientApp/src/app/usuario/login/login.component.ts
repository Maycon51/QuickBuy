import { Component } from "@angular/core"//importando do nucleo do angular
import { Usuario } from "../../modelo/usuario";
//usamos esse import para que nossa classe trabalhe como componente no angular
//tem que declarar esse component  na app module que é o principal arquivo do TS pra funcionar

@Component//decorator componente que vai injetar o produtocomponent como componente
  ({
    selector: "app-login",//nome da tag que será reenderizado
    templateUrl: "./login.component.html",
    styleUrls: ["./login.component.css"]//dentro de chaves pra definir que é uma lista e posso add mais
  })//precisamos definir qual caminho vai ser encontrado o componente

export class LoginComponent
{
  public usuario;

  constructor() {
    this.usuario = new Usuario();

  }
  entrar() {
    alert(this.usuario.email + '-' + this.usuario.senha);
  }

}
