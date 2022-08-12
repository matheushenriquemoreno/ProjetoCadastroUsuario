using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Services.Interface;

namespace Domain.Services.Implementacao
{
    public class ServiceBase<T> : IServiceBase<T> where T : IEntidadeBase
    {
        public bool Cadastrar(T entidade)
        {
            // a implementar
            return true;
        }
    }
}
