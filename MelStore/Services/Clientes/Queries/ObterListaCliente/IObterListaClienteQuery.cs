namespace MelStore.Services.Clientes.Queries.ObterListaCliente
{
  public interface IObterListaClienteQuery
  {
    Task<IEnumerable<ClienteModel>> ExecuteAsync();
  }
}
