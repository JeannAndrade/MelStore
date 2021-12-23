namespace MelStore.Services.Pedidos.Queries.ObterListaPedido
{
  public interface IObterListaPedidoQuery
  {
    Task<IEnumerable<PedidoForListModel>> ExecuteAsync();
  }
}
