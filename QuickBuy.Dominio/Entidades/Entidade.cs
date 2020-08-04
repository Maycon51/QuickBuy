using System.Collections.Generic;
using System.Linq;

namespace QuickBuy.Dominio.Entidades
{
    public abstract class Entidade
    {
        private List<string> _mensagensValidacao { get; set; }
        private List<string> mensagemValidacao
        {

            get { return _mensagensValidacao ?? (_mensagensValidacao = new List<string>()); }

        }
        /// <summary>
        /// erick fodao
        /// </summary>
        protected void LimparMensagensValidacao()// usando pra poder limpar usando esse metodo
        {
            mensagemValidacao.Clear();
        }

        protected void AdicionarCritica(string mensagem)//usamos para adicionar uma mensagem de critica nas demais classes
        {
            mensagemValidacao.Add(mensagem);// é um metodo para adicionar
        }

        public abstract void Validate();

        protected bool EhValido
        {
            get { return !mensagemValidacao.Any(); }
            // Server pra dizer " é isso mesmo" então ele vai validar a informação qué está sendo enviada
           // SE NÃO TIVER UMA MENSAGEM DE VALIDAÇÃO CONSIDERA VALIDO
        }


    }
}
