namespace MelStore.Brokers.StorageBrokers
{
  public class RepositoryManager : IRepositoryManager
  {
    private readonly RepositoryContext _repositoryContext;
    private IClienteRepository? _clienteRepository;
    private IProdutoRepository? _produtoRepository;
    private IPedidoRepository? _pedidoRepository;
    private IItemPedidoRepository? _itemPedidoRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
      _repositoryContext = repositoryContext;
    }

    public IClienteRepository Cliente
    {
      get
      {
        if (_clienteRepository == null)
          _clienteRepository = new ClienteRepository(_repositoryContext);

        return _clienteRepository;
      }
    }

    public IProdutoRepository Produto
    {
      get
      {
        if (_produtoRepository == null)
          _produtoRepository = new ProdutoRepository(_repositoryContext);

        return _produtoRepository;
      }
    }

    public IPedidoRepository Pedido
    {
      get
      {
        if (_pedidoRepository == null)
          _pedidoRepository = new PedidoRepository(_repositoryContext);

        return _pedidoRepository;
      }
    }

    public IItemPedidoRepository ItemPedido
    {
      get
      {
        if (_itemPedidoRepository == null)
          _itemPedidoRepository = new ItemPedidoRepository(_repositoryContext);

        return _itemPedidoRepository;
      }
    }

    public async Task<int> SaveAsync() => await _repositoryContext.SaveChangesAsync();
  }
}
