namespace MelStore.Services.Pedidos.Commands.UpdatePedido
{
  public class PedidoForEditionModel
  {
    public int Id { get; set; }
    public string? NomeCliente { get; set; }
    public DateTime Data { get; set; }
    public List<ItemPedidoForEditionModel> ItensPedido { get; set; } = new List<ItemPedidoForEditionModel>();


    public class ItemPedidoForEditionModel
    {
      public int Id { get; set; }
      public string? NomeProduto { get; set; }
      public string? PrecoUnitario { get; set; }
      public int Quantidade { get; set; }
    }
  }
}
