using MelStore.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MelStore.Brokers.StorageBrokers.EntitiesTypeConfiguration
{
  public class ProdutoEntityTypeConfiguration : IEntityTypeConfiguration<Produto>
  {
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
      builder.ToTable("produtos").HasComment("Tabela de produtos");
      builder.HasKey(b => b.Id);
      builder.Property(b => b.Nome).HasMaxLength(100).IsRequired();
      builder.Property(b => b.Descricao).HasMaxLength(4000);
      builder.Property(b => b.Preco).IsRequired().HasColumnType("decimal(10,2)");
    }
  }
}
