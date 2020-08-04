using System;
using System.Collections.Generic;

namespace QuickBuy.Dominio.Contratos

{
    public interface IBaseRepositorio<TEntity> : IDisposable where TEntity : class
    {
        //o ibase(nome do repositorio) vai trabalhar soomente com o TEntity
        // Idiposable serve para que a ibase herde de uma outra interface que eu digo que o tentity é uma class 
        //como serão os metodos que serão usados na camada de repositorio para acessar o banco de dados
        void Adicionar(TEntity entity);
        TEntity ObterPorId(int id);
        IEnumerable<TEntity> ObterTodos();
        void Atualizar(TEntity entity);
        void Remover(TEntity entity);

    }
}
