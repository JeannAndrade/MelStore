namespace MelStore.Services.Produtos.Queries.ObterProdutoPorId
{
  public interface IObterProdutoPorIdQuery
  {
    Task<ProdutoModel?> ExecuteAsync(int id);
  }
}
