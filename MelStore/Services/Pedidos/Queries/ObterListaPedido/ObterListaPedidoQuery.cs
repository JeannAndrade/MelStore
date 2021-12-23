using AutoMapper;
using MelStore.Brokers.StorageBrokers;

namespace MelStore.Services.Pedidos.Queries.ObterListaPedido
{
  public class ObterListaPedidoQuery : IObterListaPedidoQuery
  {
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public ObterListaPedidoQuery(IRepositoryManager repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<IEnumerable<PedidoForListModel>> ExecuteAsync()
    {
      var pedidos = await _repository.Pedido.ObterTodosAsync(trackChanges: false);
      return _mapper.Map<IEnumerable<PedidoForListModel>>(pedidos);
    }
  }
}
