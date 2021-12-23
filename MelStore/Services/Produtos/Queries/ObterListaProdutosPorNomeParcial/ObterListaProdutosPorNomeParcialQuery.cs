using AutoMapper;
using MelStore.Brokers.StorageBrokers;

namespace MelStore.Services.Produtos.Queries.ObterListaProdutosPorNomeParcial
{
  public class ObterListaProdutosPorNomeParcialQuery : IObterListaProdutosPorNomeParcialQuery
  {
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public ObterListaProdutosPorNomeParcialQuery(IRepositoryManager repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }
    public async Task<IEnumerable<ProdutoModel>> ExecuteAsync(string nome)
    {
      var produtos = await _repository.Produto.ObterPOrNomeParcialAsync(termo: nome, trackChanges: false);

      return _mapper.Map<IEnumerable<ProdutoModel>>(produtos);
    }
  }
}
