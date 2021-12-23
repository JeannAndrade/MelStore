using FluentValidation.Results;

namespace MelStore.Services.Produtos.Commands.CreateProduto
{
  public interface ICreateProdutoCommand
  {
    Task<ValidationResult> ExecuteAsync(ProdutoForCreationModel model);
  }
}
