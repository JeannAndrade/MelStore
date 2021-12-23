namespace MelStore.Services.Pedidos.Queries.ObterPedidoPorId
{
  public interface IObterPedidoPorIdQuery
  {
    Task<PedidoModel?> ExecuteAsync(int id);
  }
}
