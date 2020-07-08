using QuickBuy.Dominio.Enumerados;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Dominio.ObjetoDeValor
{
    public class FormaPagamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public bool EhBoleto
        {
            get { return Id == (int)TipoFormaPagamentoEnum.Boleto; }

        }

        public bool NaoFoiDefinido
        {
            get { return Id == (int)TipoFormaPagamentoEnum.NaoDefinido; }

        }
        public bool EhCartaoCredito
        {
            get { return Id == (int)TipoFormaPagamentoEnum.CartaoCredito; }

        }
        public bool EhDeposito
        {
            get { return Id == (int)TipoFormaPagamentoEnum.Boleto; }

        }
        //Condições que vão verificar qual a forma de pagamento deve ser utilizada
        // depende do retorno que o get receber seleciona a forma de pagamento
        //formas de pagamento foram enumeradas para isso

    }
}
