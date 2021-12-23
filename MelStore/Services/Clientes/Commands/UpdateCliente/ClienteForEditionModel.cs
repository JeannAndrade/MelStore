using System.ComponentModel.DataAnnotations;

namespace MelStore.Services.Clientes.Commands.UpdateCliente
{
  public class ClienteForEditionModel
  {
    public int Id { get; set; }
    public string? Nome { get; set; }
  }
}
