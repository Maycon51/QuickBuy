﻿using QuickBuy.Dominio.ObjetoDeValor;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Dominio.Entidades
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataPrevisaoEntrega { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string EnderecoCompleto { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public int FormaPagamentoId { get; set; }
        //identificador da forma de pagamento
        public ICollection<ItemPedido> ItensPedidos { get; set; }
        //Um pedido terá MUITOS ITENS DE pedido ou NENHUM ITEM DE PEDIDO
        // A classe PEDIDO podera ter diversos pedidos dentro dela mesmo, pois ela terá vários itens
        // que farão uso desse pedido, o pedido tem vários produtos com quantidades diferentes
        
    }
}
