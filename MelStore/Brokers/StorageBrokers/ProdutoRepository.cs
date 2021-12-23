using MelStore.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace MelStore.Brokers.StorageBrokers
{
  public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
  {
    public ProdutoRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public void Atualizar(Produto produto)
    {
      Update(produto);
    }

    public void Inserir(Produto produto)
    {
      Create(produto);
    }

    public async Task<Produto?> ObterPorIdAsync(int id, bool trackChanges)
    {
      return await FindByCondition(produto => produto.Id == id, trackChanges).FirstOrDefaultAsync();
    }

    public async Task<Produto?> ObterPorNomeAsync(string nome, bool trackChanges)
    {
      return await FindByCondition(produto => produto.Nome == nome, trackChanges).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Produto>> ObterPOrNomeParcialAsync(string termo, bool trackChanges)
    {
      return await FindByCondition(produto => produto.Nome.Contains(termo), trackChanges).ToListAsync();
    }

    public async Task<IEnumerable<Produto>> ObterTodosAsync(bool trackChanges)
    {
      return await FindAll(trackChanges).ToListAsync();
    }
  }
}
