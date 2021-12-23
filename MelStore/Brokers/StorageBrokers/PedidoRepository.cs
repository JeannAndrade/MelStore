using MelStore.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace MelStore.Brokers.StorageBrokers
{
  public class PedidoRepository : RepositoryBase<Pedido>, IPedidoRepository
  {
    public PedidoRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public void Inserir(Pedido pedido)
    {
      Create(pedido);
    }

    public async Task<Pedido?> ObterPorIdAsync(int id, bool trackChanges)
    {
      var query = !trackChanges ?
        RepositoryContext
        .Pedidos.AsNoTracking()
        .Include(i => i.Cliente)
        .Include(i => i.ItemPedidos).ThenInclude(i => i.Produto)
        .Where(i => i.Id == id)
        .Select(p => p)
        : RepositoryContext
        .Pedidos
        .Include(i => i.Cliente)
        .Include(i => i.ItemPedidos).ThenInclude(i => i.Produto)
        .Where(i => i.Id == id)
        .Select(p => p);

      return await query.FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Pedido>> ObterTodosAsync(bool trackChanges)
    {
      var query = !trackChanges ?
        RepositoryContext
        .Pedidos.AsNoTracking()
        .Include(i => i.Cliente)
        .Include(i => i.ItemPedidos)
        .Select(p => p)
        : RepositoryContext
        .Pedidos
        .Include(i => i.Cliente)
        .Include(i => i.ItemPedidos)
        .Select(p => p);

      return await query.ToListAsync();
    }
  }
}
