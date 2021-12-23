using MelStore.Core.Models;

namespace MelStore.Brokers.StorageBrokers
{
  public interface IPedidoRepository
  {
    Task<Pedido?> ObterPorIdAsync(int id, bool trackChanges);
    Task<IEnumerable<Pedido>> ObterTodosAsync(bool trackChanges);
    void Inserir(Pedido pedido);
  }
}
