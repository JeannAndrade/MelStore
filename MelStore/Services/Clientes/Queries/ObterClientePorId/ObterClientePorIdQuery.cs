using AutoMapper;
using MelStore.Brokers.StorageBrokers;

namespace MelStore.Services.Clientes.Queries.ObterClientePorId
{
  public class ObterClientePorIdQuery : IObterClientePorIdQuery
  {
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public ObterClientePorIdQuery(IRepositoryManager repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }
    public async Task<ClienteModel?> ExecuteAsync(int id)
    {
      var cliente = await _repository.Cliente.ObterPorIdAsync(id: id, trackChanges: false);      

      return cliente is null ? null : _mapper.Map<ClienteModel>(cliente);
    }
  }
}
