namespace MelStore.Brokers.StorageBrokers
{
  public interface IRepositoryManager
  {
    IClienteRepository Cliente { get; }
    IProdutoRepository Produto { get; }
    IPedidoRepository Pedido { get; }
    IItemPedidoRepository ItemPedido { get; }
    Task<int> SaveAsync();
  }
}
