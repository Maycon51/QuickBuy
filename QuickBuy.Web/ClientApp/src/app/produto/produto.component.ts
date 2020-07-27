import {Component } from "@angular/core"//importando do nucleo do angular
//usamos esse import para que nossa classe trabalhe como componente no angular
//tem que declarar esse component  na app module que é o principal arquivo do TS pra funcionar

@Component//decorator componente que vai injetar o produtocomponent como componente
  ({
    selector: "produto",//nome da tag que será reenderizado
    template: "<html><body>{{  obterNome()  }}</body></html>"
})//precisamos definir no template qual sera 

export class ProdutoComponent //export serve pra deixar publico e qualquer um acessar essa classe
{ // nome de variavel em TS começa maiuscula
  // nome das classes são com M por conveção (PascalCase)
  public nome: string;//variavel interna começa com minuscula (camelCase)
  public liberadoParaVenda: boolean; //nome composto começa com maiscula

  public obterNome(): string
  {


    return "Samsung";//this.nome;//função que retorna o nome do tipo string
  }
}
