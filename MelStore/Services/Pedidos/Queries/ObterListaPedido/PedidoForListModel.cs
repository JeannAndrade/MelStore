namespace MelStore.Services.Pedidos.Queries.ObterListaPedido
{
  public class PedidoForListModel
  {
    public int Id { get; set; }
    public string NomeCliente { get; set; }
    public DateTime Data { get; set; }
    public int QuantidadeItens { get; set; }
    public decimal ValorTotal { get; set; }
  }
}
