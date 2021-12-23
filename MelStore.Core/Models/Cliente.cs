using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelStore.Core.Models
{
  public class Cliente
  {
    public Cliente(string? nome)
    {
      Nome = nome ?? string.Empty;
    }

    public int Id { get; private set; }
    public string Nome { get; private set; }

    public void AtualizarNome(string? novoNome) => Nome = novoNome ?? string.Empty;

    public ICollection<Pedido> Pedidos { get; } = new List<Pedido>();
  }
}
