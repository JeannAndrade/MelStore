using FluentValidation;
using MelStore.Brokers.DateTimeBrokers;
using MelStore.Core.Models;

namespace MelStore.Services.Validators
{
    public class PedidoValidator : AbstractValidator<Pedido>
    {
        public PedidoValidator(IDateProvider dateProvider)
        {
            RuleFor(pedido => pedido.Data).Must(data => data <= dateProvider.ObterDataAtual()).WithMessage("A data do pedido não é válida");
            RuleFor(pedido => pedido.Cliente).NotNull().WithMessage("O pedido deve ter um cliente associado");
            RuleFor(pedido => pedido.ItemPedidos).Must(itens => itens.Count > 0).WithMessage("O pedido deve ter itens associados");
            RuleForEach(pedido => pedido.ItemPedidos).SetValidator(new ItemPedidoValidator());
        }
    }
}
