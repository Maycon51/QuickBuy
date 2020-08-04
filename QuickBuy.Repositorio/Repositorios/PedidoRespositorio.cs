using QuickBuy.Dominio.Entidades;
using QuickBuy.Dominio.Contratos;
using System.Collections.Generic;
using System.Text;
using QuickBuy.Repositorio.Contexto;

namespace QuickBuy.Repositorio.Repositorios
{
    public class PedidoRespositorio : BaseRepositorio<Pedido>, IPedidoRepositorio
    {
        public PedidoRespositorio(QuickBuyContexto quickBuyContexto) : base(quickBuyContexto)
        {
        }
    }
}