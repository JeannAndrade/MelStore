using MelStore.Brokers.StorageBrokers.EntitiesTypeConfiguration;
using MelStore.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace MelStore.Brokers.StorageBrokers
{
  public class RepositoryContext : DbContext
  {
    public RepositoryContext(DbContextOptions options)
    : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new ClienteEntityTypeConfiguration());
      modelBuilder.ApplyConfiguration(new ProdutoEntityTypeConfiguration());
      modelBuilder.ApplyConfiguration(new PedidoEntityTypeConfiguration());
      modelBuilder.ApplyConfiguration(new ItemPedidoEntityTypeConfiguration());
    }

    public DbSet<Cliente>? Clientes { get; set; }
    public DbSet<Produto>? Produtos { get; set; }
    public DbSet<Pedido>? Pedidos { get; set; }
    public DbSet<ItemPedido>? ItensPedido { get; set; }
  }
}
