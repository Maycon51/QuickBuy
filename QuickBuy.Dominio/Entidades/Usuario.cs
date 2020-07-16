using System.Collections;
using System.Collections.Generic;

namespace QuickBuy.Dominio.Entidades
{
    public class Usuario : Entidade
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
        //o collection relaciona o usuario com o pedidos, pois um usuario pode ter vários pedidos ou nenhum
        // o virtual vai fazer que o sistema permita a sobreposição em tempo de execução
        public override void Validate()
        {
            if (string.IsNullOrEmpty(Email))
                AdicionarCritica("Email não informado");
            if (string.IsNullOrEmpty(Senha))
                AdicionarCritica("Senha não informada");
        }
        //Utilizamos para quando o usuário pode ter vários pedidos ou nenhum
    }
}
