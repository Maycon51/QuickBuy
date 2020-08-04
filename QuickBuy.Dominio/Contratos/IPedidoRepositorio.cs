using QuickBuy.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Dominio.Contratos
{
    public interface IPedidoRepositorio : IBaseRepositorio<Pedido>
    //criamos um contrato para a classe pedido somente
    //como ele herdou da ibase ele não precisa criar os metodos da interface
    //de atualizar remover etc.
    {
    }
}
