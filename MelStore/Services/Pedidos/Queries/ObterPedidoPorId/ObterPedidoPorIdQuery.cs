using AutoMapper;
using MelStore.Brokers.StorageBrokers;

namespace MelStore.Services.Pedidos.Queries.ObterPedidoPorId
{
  public class ObterPedidoPorIdQuery : IObterPedidoPorIdQuery
  {
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public ObterPedidoPorIdQuery(IRepositoryManager repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<PedidoModel?> ExecuteAsync(int id)
    {
      var pedido = await _repository.Pedido.ObterPorIdAsync(id, trackChanges: false);
      return _mapper.Map<PedidoModel>(pedido);
    }
  }
}
