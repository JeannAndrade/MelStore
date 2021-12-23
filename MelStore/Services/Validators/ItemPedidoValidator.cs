using FluentValidation;
using MelStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelStore.Services.Validators
{
  public class ItemPedidoValidator : AbstractValidator<ItemPedido>
  {
    public ItemPedidoValidator()
    {
      RuleFor(itemPedido => itemPedido.Produto).NotNull().WithMessage("O item do pedido deve ter um produto associado");
      RuleFor(itemPedido => itemPedido.PrecoUnitario).Must(precoVenda => precoVenda > 0).WithMessage("O preço de venda do item deve ser maior que 0");
      RuleFor(itemPedido => itemPedido.Quantidade).Must(quantidade => quantidade > 0).WithMessage("A quantidade de itens do produto vendido deve ser maior que 0");
    }
  }
}
