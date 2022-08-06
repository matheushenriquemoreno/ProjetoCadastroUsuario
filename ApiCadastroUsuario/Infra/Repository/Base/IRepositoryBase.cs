using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Infra.Repository.Base
{
    public interface IRepositoryBase<T> where T : IEntidadeBase 
    {
        T BuscaPeloID(int id);
        IEnumerable<T> BuscaTodos();
        IEnumerable<T> BuscaTodosOnde(Expression<Func<T, bool>> expression);
        void Adiciona(T entidade);
        void Atualiza(T entidade);
        void Remover(T objeto);
    }
}
