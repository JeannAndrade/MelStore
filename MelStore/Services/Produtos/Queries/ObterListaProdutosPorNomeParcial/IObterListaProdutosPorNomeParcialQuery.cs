namespace MelStore.Services.Produtos.Queries.ObterListaProdutosPorNomeParcial
{
    public interface IObterListaProdutosPorNomeParcialQuery
    {
        Task<IEnumerable<ProdutoModel>> ExecuteAsync(string nome);
    }
}
