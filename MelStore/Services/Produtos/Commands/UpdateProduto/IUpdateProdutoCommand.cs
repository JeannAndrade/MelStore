using FluentValidation.Results;

namespace MelStore.Services.Produtos.Commands.UpdateProduto
{
  public interface IUpdateProdutoCommand
  {
    Task<ValidationResult> ExecuteAsync(ProdutoForEditionModel model);
  }
}
