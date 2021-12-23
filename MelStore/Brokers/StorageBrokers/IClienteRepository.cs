using MelStore.Core.Models;

namespace MelStore.Brokers.StorageBrokers
{
  public interface IClienteRepository
  {
    Task<IEnumerable<Cliente>> ObterTodosAsync(bool trackChanges);
    Task<IEnumerable<Cliente>> ObterPOrNomeParcialAsync(string termo, bool trackChanges);
    Task<Cliente?> ObterPorIdAsync(int id, bool trackChanges);
    Task<Cliente?> ObterPorNomeAsync(string nome, bool trackChanges);
    void Inserir(Cliente cliente);
    void Atualizar(Cliente cliente);
  }
}
