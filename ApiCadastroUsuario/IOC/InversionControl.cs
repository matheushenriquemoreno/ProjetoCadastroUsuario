using Infra.Data;
using Infra.Repository.RepositoryUsuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IOC
{
    public static class InversionControl
    {
        public static void RegistrarServicos(IServiceCollection services)
        {
            services.AddScoped<IReporitoryUsuario, RepositoryUsuario>();
            


        }
    }
}