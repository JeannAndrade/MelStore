namespace MelStore.Services.Pedidos.Commands.CreatePedido
{
  public class PedidoForCreationModel
  {
    public string? NomeCliente { get; set; }
    public DateTime Data { get; set; }
    public List<ItemPedidoForCreationModel> ItensPedido { get; set; } = new List<ItemPedidoForCreationModel>();
  }

  public class ItemPedidoForCreationModel
  {
    public string? NomeProduto { get; set; }
    public string? PrecoUnitario { get; set; }
    public int Quantidade { get; set; }
  }
}
