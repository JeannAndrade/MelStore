using MelStore.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MelStore.Brokers.StorageBrokers.EntitiesTypeConfiguration
{
  public class PedidoEntityTypeConfiguration : IEntityTypeConfiguration<Pedido>
  {
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
      builder.ToTable("pedidos").HasComment("Tabela de pedidos");
      builder.HasKey(b => b.Id);
      builder.Property(b => b.Data).IsRequired();
    }
  }
}
