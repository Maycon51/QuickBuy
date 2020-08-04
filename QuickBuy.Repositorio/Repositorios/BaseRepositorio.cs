using QuickBuy.Dominio.Contratos;
using QuickBuy.Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBuy.Repositorio.Repositorios
{


    public class BaseRepositorio<TEntity> : IBaseRepositorio<TEntity> where TEntity : class
    {
        protected readonly QuickBuyContexto QuickBuyContexto;
        //se tiver private somente a classe direta vai receber
        //se tiver protected as classes filhas também recebem
        public BaseRepositorio(QuickBuyContexto quickBuyContexto)
        {
            QuickBuyContexto = quickBuyContexto;
        }//armazenando o metodo para que seja feito a configuração em tempo real usando o db context
        public void Adicionar(TEntity entity)
        {
            QuickBuyContexto.Set<TEntity>().Add(entity);
            QuickBuyContexto.SaveChanges();
        }

        public void Atualizar(TEntity entity)
        {
            QuickBuyContexto.Set<TEntity>().Update(entity);
            QuickBuyContexto.SaveChanges();
        }

          public TEntity ObterPorId(int id)
        {
            return QuickBuyContexto.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
          return  QuickBuyContexto.Set<TEntity>().ToList();//precisa retornar algo
            
        }

        public void Remover(TEntity entity)
        {
            QuickBuyContexto.Set<TEntity>().Remove(entity);
            QuickBuyContexto.SaveChanges();
        }
        public void Dispose()//pra apagar da memoria, em algum momento ele é invocado
        {
            QuickBuyContexto.Dispose();
           
        }
    }
}
