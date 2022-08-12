using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entidades;
using Domain.Services.Interface;
using Domain.Validators;
using Infra.Repository.RepositoryUsuario;

namespace Domain.Services.Implementacao
{
    public class ServiceUsuario : IServiceUsuario
    {
        private readonly IReporitoryUsuario repositoryUsuario;

        public ServiceUsuario(IReporitoryUsuario reporitoryUsuario)
        {
            this.repositoryUsuario = reporitoryUsuario;
        }

        public bool Cadastrar(Usuario usuario)
        {

            var validator = new UsuarioValidator();

            var resultado = validator.Validate(usuario);


            if (resultado.IsValid)
            {
                repositoryUsuario.Adiciona(usuario);

                return true;
            }

            var erros = resultado.Errors;

            return false;

        }
    }
}
