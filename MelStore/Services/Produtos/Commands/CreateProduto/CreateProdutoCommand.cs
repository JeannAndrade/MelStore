using FluentValidation.Results;
using MelStore.Brokers.StorageBrokers;
using MelStore.Core.Models;
using MelStore.Services.Validators;

namespace MelStore.Services.Produtos.Commands.CreateProduto
{
  public class CreateProdutoCommand : ICreateProdutoCommand
  {
    private readonly IRepositoryManager _repository;

    public CreateProdutoCommand(IRepositoryManager repository)
    {
      _repository = repository;
    }

    public async Task<ValidationResult> ExecuteAsync(ProdutoForCreationModel model)
    {
      var produto = new Produto(model.Nome, model.Descricao, model.Preco);
      var validator = new ProdutoValidator();
      var results = await validator.ValidateAsync(produto);

      if (results.IsValid)
      {
        _repository.Produto.Inserir(produto);
        await _repository.SaveAsync();
      }

      return results;
    }
  }
}
