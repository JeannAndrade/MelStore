namespace MelStore.Services.Produtos.Commands.CreateProduto
{
  public class ProdutoForCreationModel
  {
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public decimal Preco { get; set; }
  }
}
