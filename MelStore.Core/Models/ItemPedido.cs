namespace MelStore.Core.Models
{
  public class ItemPedido
  {
    public ItemPedido(decimal precoUnitario, int quantidade)
    {
      PrecoUnitario = precoUnitario;
      Quantidade = quantidade;
    }

    public int Id { get; private set; }
    public decimal PrecoUnitario { get; private set; }
    public int Quantidade { get; private set; }
    public Pedido? Pedido { get; private set; }
    public Produto? Produto { get; private set; }

    public void DefinirPrduto(Produto? produto) => Produto = produto;
  }
}
