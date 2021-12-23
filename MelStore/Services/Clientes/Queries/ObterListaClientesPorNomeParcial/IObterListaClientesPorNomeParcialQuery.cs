namespace MelStore.Services.Clientes.Queries.ObterListaClientesPorNomeParcial
{
  public interface IObterListaClientesPorNomeParcialQuery
  {
    Task<IEnumerable<ClienteModel>> ExecuteAsync(string termo);
  }
}
