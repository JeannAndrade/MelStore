using AutoMapper;
using MelStore.Brokers.StorageBrokers;

namespace MelStore.Services.Produtos.Queries.ObterProdutoPorId
{
  public class ObterProdutoPorIdQuery : IObterProdutoPorIdQuery
  {
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public ObterProdutoPorIdQuery(IRepositoryManager repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }
    public async Task<ProdutoModel?> ExecuteAsync(int id)
    {
      var produto = await _repository.Produto.ObterPorIdAsync(id: id, trackChanges: false);

      return produto is null ? null : _mapper.Map<ProdutoModel>(produto);
    }
  }
}
