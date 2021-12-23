using MelStore.Core.Models;

namespace MelStore.Brokers.StorageBrokers
{
  public class ItemPedidoRepository : RepositoryBase<ItemPedido>, IItemPedidoRepository
  {
    public ItemPedidoRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
  }
}
