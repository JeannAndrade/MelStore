namespace MelStore.Core.Models
{
  public class Pedido
  {
    public Pedido(DateTime data)
    {
      Data = data;
    }

    public int Id { get; private set; }
    public DateTime Data { get; private set; }
    public Cliente? Cliente { get; private set; }

    public ICollection<ItemPedido> ItemPedidos { get; } = new List<ItemPedido>();

    public void DefinirCliente(Cliente? cliente) => Cliente = cliente;
    public void AdicionarItemPedido(ItemPedido item) => ItemPedidos.Add(item);
  }
}
