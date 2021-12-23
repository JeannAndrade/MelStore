using MelStore.Core.Models;

namespace MelStore.Brokers.StorageBrokers
{
  public interface IProdutoRepository
  {
    Task<IEnumerable<Produto>> ObterTodosAsync(bool trackChanges);
    Task<IEnumerable<Produto>> ObterPOrNomeParcialAsync(string termo, bool trackChanges);
    Task<Produto?> ObterPorIdAsync(int id, bool trackChanges);
    Task<Produto?> ObterPorNomeAsync(string nome, bool trackChanges);
    void Inserir(Produto produto);
    void Atualizar(Produto produto);
  }
}
