using FluentValidation.Results;
using MelStore.Brokers.StorageBrokers;
using MelStore.Services.Validators;

namespace MelStore.Services.Produtos.Commands.UpdateProduto
{
  public class UpdateProdutoCommand: IUpdateProdutoCommand
  {
    private readonly IRepositoryManager _repository;

    public UpdateProdutoCommand(IRepositoryManager repository)
    {
      _repository = repository;
    }

    public async Task<ValidationResult> ExecuteAsync(ProdutoForEditionModel model)
    {
      var produto = await _repository.Produto.ObterPorIdAsync(model.Id, trackChanges: true);

      if (produto != null)
      {
        produto.AtualizarNome(model.Nome);
        produto.AtualizarDescricao(model.Descricao);
        produto.AtualizarPreco(model.Preco);
        var validator = new ProdutoValidator();
        var results = await validator.ValidateAsync(produto);

        if (results.IsValid)
        {
          _repository.Produto.Atualizar(produto);
          await _repository.SaveAsync();
        }

        return results;
      }
      else
        return new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("Id", "Identificador não encontrado") });
    }
  }
}
