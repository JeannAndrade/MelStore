using System.ComponentModel.DataAnnotations;

namespace MelStore.Services.Clientes.Commands.CreateCliente
{
  public class ClienteForCreationModel
  {
    [Required(ErrorMessage = "Por favor informe seu nome")]
    public string? Nome { get; set; }
  }
}
