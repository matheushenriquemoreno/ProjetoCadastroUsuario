using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, IEntidadeBase
    {

        private readonly DbContext _context;

        public RepositoryBase(DbContext context)
        {
            _context = context;
        }

        public void Adiciona(T entidade)
        {
            _context.Set<T>().Add(entidade);
            Salvar();
        }

        public void Atualiza(T entidade)
        {
            _context.Set<T>().Update(entidade);
            Salvar();
        }

        public T BuscaPeloID(int id)
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<T> BuscaTodos()
        {
          return _context.Set<T>().ToList();
        }

        public IEnumerable<T> BuscaTodosOnde(Expression<Func<T, bool>> expression)
        {
             return _context.Set<T>().Where(expression).ToList();
        }

        public void Remover(T objeto)
        {
            _context.Set<T>().Remove(objeto);
            Salvar();
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
