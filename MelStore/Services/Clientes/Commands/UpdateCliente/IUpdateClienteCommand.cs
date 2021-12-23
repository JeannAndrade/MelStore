using FluentValidation.Results;

namespace MelStore.Services.Clientes.Commands.UpdateCliente
{
  public interface IUpdateClienteCommand
  {
    Task<ValidationResult> ExecuteAsync(ClienteForEditionModel model);
  }
}
