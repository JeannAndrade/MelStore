using FluentValidation;
using MelStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelStore.Services.Validators
{
  public class ProdutoValidator : AbstractValidator<Produto>
  {
    public ProdutoValidator()
    {
      RuleFor(produto => produto.Nome).NotEmpty().WithMessage("Nome do produto é obrigatório");
      RuleFor(produto => produto.Nome).MaximumLength(100).WithMessage("Nome do produto deve ter no máximo 100 caracteres");
      RuleFor(produto => produto.Descricao).NotEmpty().WithMessage("Descrição do produto é obrigatório");
      RuleFor(produto => produto.Descricao).MaximumLength(4000).WithMessage("Descrição do produto deve ter no máximo 4000 caracteres");
      RuleFor(produto => produto.Preco).Must(preco => preco > 0).WithMessage("O produto deve ter um preço maior que 0");
    }
  }
}
