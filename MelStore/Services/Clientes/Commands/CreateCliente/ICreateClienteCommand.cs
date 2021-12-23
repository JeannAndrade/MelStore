using FluentValidation.Results;

namespace MelStore.Services.Clientes.Commands.CreateCliente
{
  public interface ICreateClienteCommand
  {
    Task<ValidationResult> ExecuteAsync(ClienteForCreationModel model);
  }
}
