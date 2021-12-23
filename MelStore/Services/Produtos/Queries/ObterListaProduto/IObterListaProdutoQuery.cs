namespace MelStore.Services.Produtos.Queries.ObterListaProduto
{
  public interface IObterListaProdutoQuery
  {
    Task<IEnumerable<ProdutoModel>> ExecuteAsync();
  }
}
