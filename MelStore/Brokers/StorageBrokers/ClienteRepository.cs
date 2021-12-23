using MelStore.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace MelStore.Brokers.StorageBrokers
{
  public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
  {
    public ClienteRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public void Atualizar(Cliente cliente)
    {
      Update(cliente);
    }

    public void Inserir(Cliente cliente)
    {
      Create(cliente);
    }

    public async Task<Cliente?> ObterPorIdAsync(int id, bool trackChanges)
    {
      return await FindByCondition(cliente => cliente.Id == id, trackChanges).FirstOrDefaultAsync();
    }

    public async Task<Cliente?> ObterPorNomeAsync(string nome, bool trackChanges)
    {
      return await FindByCondition(cliente => cliente.Nome == nome, trackChanges).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Cliente>> ObterPOrNomeParcialAsync(string termo, bool trackChanges)
    {
      return await FindByCondition(cliente => cliente.Nome.Contains(termo), trackChanges).ToListAsync();
    }

    public async Task<IEnumerable<Cliente>> ObterTodosAsync(bool trackChanges)
    {
      return await FindAll(trackChanges).ToListAsync();
    }
  }
}
