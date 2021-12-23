using AutoMapper;
using MelStore.Brokers.StorageBrokers;

namespace MelStore.Services.Clientes.Queries.ObterListaClientesPorNomeParcial
{
  public class ObterListaClientesPorNomeParcialQuery : IObterListaClientesPorNomeParcialQuery
  {
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public ObterListaClientesPorNomeParcialQuery(IRepositoryManager repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<IEnumerable<ClienteModel>> ExecuteAsync(string termo)
    {
      var clientes = await _repository.Cliente.ObterPOrNomeParcialAsync(termo: termo, trackChanges: false);
        return _mapper.Map<IEnumerable<ClienteModel>>(clientes);
    }
  }
}
