using MelStore.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MelStore.Brokers.StorageBrokers.EntitiesTypeConfiguration
{
  public class ClienteEntityTypeConfiguration : IEntityTypeConfiguration<Cliente>
  {
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
      builder.ToTable("clientes").HasComment("Tabela de clientes");
      builder.HasKey(b => b.Id);
      builder.Property(b => b.Nome).HasMaxLength(50).IsRequired().HasComment("Nome do cliente");
    }
  }
}
