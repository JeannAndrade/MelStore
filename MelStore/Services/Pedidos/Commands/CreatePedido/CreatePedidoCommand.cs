using FluentValidation.Results;
using MelStore.Brokers.DateTimeBrokers;
using MelStore.Brokers.StorageBrokers;
using MelStore.Core.Models;
using MelStore.Services.Validators;
using System.Globalization;

namespace MelStore.Services.Pedidos.Commands.CreatePedido
{
  public class CreatePedidoCommand : ICreatePedidoCommand
  {
    private readonly IRepositoryManager _repository;
    private readonly IDateProvider _dateProvider;

    public CreatePedidoCommand(IRepositoryManager repository, IDateProvider dateProvider)
    {
      _repository = repository;
      _dateProvider = dateProvider;
    }

    public async Task<ValidationResult> ExecuteAsync(PedidoForCreationModel model)
    {
      var culture = CultureInfo.CreateSpecificCulture("pt-BR");

      if (model == null)
        return new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("model", "Informações incompletas para criar um pedido") });

      var pedido = new Pedido(model.Data.ToUniversalTime());
      var cliente = await _repository.Cliente.ObterPorNomeAsync(model.NomeCliente ?? String.Empty, trackChanges: true);
      pedido.DefinirCliente(cliente);

      foreach (var item in model.ItensPedido)
      {
        var produto = await _repository.Produto.ObterPorNomeAsync(item.NomeProduto ?? String.Empty, trackChanges: true);
        if (decimal.TryParse(item.PrecoUnitario, NumberStyles.AllowDecimalPoint, culture, out decimal preco))
        { 
          var itemPedido = new ItemPedido(preco, item.Quantidade);
          itemPedido.DefinirPrduto(produto);
          pedido.AdicionarItemPedido(itemPedido);
        }
        else
          return new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("model", "O preço usuário está num formato inválido.") });
      }

      var validator = new PedidoValidator(_dateProvider);
      var results = await validator.ValidateAsync(pedido);

      if (results.IsValid)
      {
        _repository.Pedido.Inserir(pedido);
        await _repository.SaveAsync();
      }

      return results;
    }
  }
}
