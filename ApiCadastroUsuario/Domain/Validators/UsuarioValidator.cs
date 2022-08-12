using Domain.Entidades;
using FluentValidation;

namespace Domain.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {

        public UsuarioValidator()
        {
            RuleFor(x => x.Nome).NotEmpty();
            RuleFor(x => x.CPF).NotEmpty().Length(11,11);
            RuleFor(x => x.DataNascimento).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email invalido!");
        }
    }
}
