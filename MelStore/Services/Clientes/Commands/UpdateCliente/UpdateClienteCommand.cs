using FluentValidation.Results;
using MelStore.Brokers.StorageBrokers;
using MelStore.Services.Validators;

namespace MelStore.Services.Clientes.Commands.UpdateCliente
{
  public class UpdateClienteCommand : IUpdateClienteCommand
  {

    private readonly IRepositoryManager _repository;

    public UpdateClienteCommand(IRepositoryManager repository)
    {
      _repository = repository;
    }

    public async Task<ValidationResult> ExecuteAsync(ClienteForEditionModel model)
    {
      var cliente = await _repository.Cliente.ObterPorIdAsync(model.Id, trackChanges: true);

      if (cliente != null)
      {
        cliente.AtualizarNome(model.Nome);
        var validator = new ClienteValidator();
        var results = await validator.ValidateAsync(cliente);

        if (results.IsValid)
        {
          _repository.Cliente.Atualizar(cliente);
          await _repository.SaveAsync();
        }

        return results;
      }
      else
        return new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("Id", "Identificador não encontrado") });
    }
  }
}
