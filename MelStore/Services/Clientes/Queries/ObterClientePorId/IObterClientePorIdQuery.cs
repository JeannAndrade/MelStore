namespace MelStore.Services.Clientes.Queries.ObterClientePorId
{
  public interface IObterClientePorIdQuery
  {
    Task<ClienteModel?> ExecuteAsync(int id);
  }
}
