using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelStore.Core.Models
{
  public class Produto
  {
    public Produto(string? nome, string? descricao, decimal preco)
    {      
      Nome = nome ?? string.Empty;
      Descricao = descricao ?? string.Empty;
      Preco = preco;
    }

    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string Descricao { get; private set; }
    public decimal Preco { get; private set; }

    public void AtualizarNome(string? novoNome) => Nome = novoNome ?? string.Empty;
    public void AtualizarDescricao(string? novaDescricao) => Descricao = novaDescricao ?? string.Empty;
    public void AtualizarPreco(decimal novoPreco) => Preco = novoPreco;
  }
}
