using FluentValidation.Results;

namespace MelStore.Services.Pedidos.Commands.CreatePedido
{
  public interface ICreatePedidoCommand
  {
    Task<ValidationResult> ExecuteAsync(PedidoForCreationModel model);
  }
}
