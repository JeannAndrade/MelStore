using FluentValidation.Results;
using MelStore.Brokers.StorageBrokers;
using MelStore.Core.Models;
using MelStore.Services.Validators;

namespace MelStore.Services.Clientes.Commands.CreateCliente
{
  public class CreateClienteCommand : ICreateClienteCommand
  {
    private readonly IRepositoryManager _repository;

    public CreateClienteCommand(IRepositoryManager repository)
    {
      _repository = repository;
    }

    public async Task<ValidationResult> ExecuteAsync(ClienteForCreationModel model)
    {
      var cliente = new Cliente(model.Nome);
      var validator = new ClienteValidator();
      var results = await validator.ValidateAsync(cliente);

      if (results.IsValid)
      {
        _repository.Cliente.Inserir(cliente);
        await _repository.SaveAsync();
      }

      return results;
    }
  }
}
