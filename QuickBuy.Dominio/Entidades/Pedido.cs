using QuickBuy.Dominio.ObjetoDeValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBuy.Dominio.Entidades
{
    public class Pedido : Entidade
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }//propriedade que eu to fazendo o mapeamento
        //o EF entende como o primeiro nome é igual ao primeiro do usuarioid faz essa relação com o pedido
        public DateTime DataPrevisaoEntrega { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string EnderecoCompleto { get; set; }
        public int NumeroEndereco { get; set; }
        public virtual FormaPagamento FormaPagamento { get; set; }
        public int FormaPagamentoId { get; set; }
        //identificador da forma de pagamento
        public virtual ICollection<ItemPedido> ItensPedidos { get; set; }
        //Um pedido terá MUITOS ITENS DE pedido ou NENHUM ITEM DE PEDIDO
        // A classe PEDIDO podera ter diversos pedidos dentro dela mesmo, pois ela terá vários itens
        // que farão uso desse pedido, o pedido tem vários produtos com quantidades diferentes

        public override void Validate()// estamos utilizando esse metodo para validar se tem um item e se não tiver ele vai mostrar a mensagem de validação
        {
            LimparMensagensValidacao();

            if (!ItensPedidos.Any())
                AdicionarCritica("Crítica: Pedido não pode ficar sem item de pedido");
            
            if (string.IsNullOrEmpty(CEP))
                AdicionarCritica("Crítica: CEP deve estar preenchido");
            if (FormaPagamentoId == 0)
                AdicionarCritica("Não foi informada a forma de pagamento");
             // estamos utilizando esse metodo para validar se tem um item e se não tiver ele vai
            // mostrar a mensagem de validação

        }

    }
}
