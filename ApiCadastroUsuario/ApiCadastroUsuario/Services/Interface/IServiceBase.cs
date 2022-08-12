using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Services.Interface
{
    public interface IServiceBase<T> where T : IEntidadeBase
    {

        bool Cadastrar(T entidade);

    }
}
