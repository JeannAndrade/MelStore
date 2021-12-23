using AutoMapper;
using MelStore.Brokers.StorageBrokers;

namespace MelStore.Services.Produtos.Queries.ObterListaProduto
{
  public class ObterListaProdutoQuery : IObterListaProdutoQuery
  {
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public ObterListaProdutoQuery(IRepositoryManager repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<IEnumerable<ProdutoModel>> ExecuteAsync()
    {
      var produtos = await _repository.Produto.ObterTodosAsync(trackChanges: false);

      return _mapper.Map<IEnumerable<ProdutoModel>>(produtos);
    }
  }
}
