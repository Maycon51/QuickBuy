using QuickBuy.Dominio.Entidades;

namespace QuickBuy.Dominio.Contratos
{
    public interface IUsuarioRepositorio : IBaseRepositorio<Usuario>
    {
        //criamos um contrato para a classe usuario somente
        //como ele herdou da ibase ele não precisa criar os metodos da interface
        //de atualizar remover etc.

    }
}
