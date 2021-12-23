using MelStore.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MelStore.Brokers.StorageBrokers.EntitiesTypeConfiguration
{
  public class ItemPedidoEntityTypeConfiguration : IEntityTypeConfiguration<ItemPedido>
  {
    public void Configure(EntityTypeBuilder<ItemPedido> builder)
    {
      builder.ToTable("pedido_itens").HasComment("Tabela de itens de pedido");
      builder.HasKey(b => b.Id);
      builder.Property(b => b.PrecoUnitario).IsRequired().HasColumnType("decimal(10,2)");
      builder.Property(b => b.Quantidade).IsRequired();
    }
  }
}
