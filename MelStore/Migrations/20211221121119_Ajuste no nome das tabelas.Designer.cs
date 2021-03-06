// <auto-generated />
using System;
using MelStore.Brokers.StorageBrokers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MelStore.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20211221121119_Ajuste no nome das tabelas")]
    partial class Ajustenonomedastabelas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MelStore.Core.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasComment("Nome do cliente");

                    b.HasKey("Id");

                    b.ToTable("clientes", (string)null);

                    b.HasComment("Tabela de clientes");
                });

            modelBuilder.Entity("MelStore.Core.Models.ItemPedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("PedidoId")
                        .HasColumnType("integer");

                    b.Property<decimal>("PrecoUnitario")
                        .HasColumnType("numeric(10,2)");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("pedido_itens", (string)null);

                    b.HasComment("Tabela de itens de pedido");
                });

            modelBuilder.Entity("MelStore.Core.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Data")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("pedidos", (string)null);

                    b.HasComment("Tabela de pedidos");
                });

            modelBuilder.Entity("MelStore.Core.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("character varying(4000)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("numeric(10,2)");

                    b.HasKey("Id");

                    b.ToTable("produtos", (string)null);

                    b.HasComment("Tabela de produtos");
                });

            modelBuilder.Entity("MelStore.Core.Models.ItemPedido", b =>
                {
                    b.HasOne("MelStore.Core.Models.Pedido", "Pedido")
                        .WithMany("ItemPedidos")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MelStore.Core.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("MelStore.Core.Models.Pedido", b =>
                {
                    b.HasOne("MelStore.Core.Models.Cliente", "Cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("MelStore.Core.Models.Cliente", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("MelStore.Core.Models.Pedido", b =>
                {
                    b.Navigation("ItemPedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
