using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entidades;
using Infra.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository.RepositoryUsuario
{
    public class RepositoryUsuario : RepositoryBase<Usuario>, IReporitoryUsuario 
    {
        public RepositoryUsuario(DbContext context) : base(context)
        {
        }
    }
}
