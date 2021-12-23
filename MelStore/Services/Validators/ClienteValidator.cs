using FluentValidation;
using MelStore.Core.Models;

namespace MelStore.Services.Validators
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(cliente => cliente.Nome).NotEmpty().WithMessage("Nome do cliente é obrigatório");
            RuleFor(cliente => cliente.Nome).MaximumLength(50).WithMessage("Nome do cliente deve ter no máximo 50 caracteres");
        }
    }
}
