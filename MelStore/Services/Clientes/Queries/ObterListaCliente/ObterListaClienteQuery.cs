using AutoMapper;
using MelStore.Brokers.StorageBrokers;

namespace MelStore.Services.Clientes.Queries.ObterListaCliente
{
  public class ObterListaClienteQuery : IObterListaClienteQuery
  {
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public ObterListaClienteQuery(IRepositoryManager repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<IEnumerable<ClienteModel>> ExecuteAsync()
    {
      var clientes = await _repository.Cliente.ObterTodosAsync(trackChanges: false);

      return _mapper.Map<IEnumerable<ClienteModel>>(clientes);

    }
  }
}
