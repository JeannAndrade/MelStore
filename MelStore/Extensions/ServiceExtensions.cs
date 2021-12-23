using FluentValidation;
using MelStore.Brokers.DateTimeBrokers;
using MelStore.Brokers.LoggerBrokers;
using MelStore.Brokers.StorageBrokers;
using MelStore.Core.Models;
using MelStore.Services.Clientes.Commands.CreateCliente;
using MelStore.Services.Clientes.Commands.UpdateCliente;
using MelStore.Services.Clientes.Queries.ObterClientePorId;
using MelStore.Services.Clientes.Queries.ObterListaCliente;
using MelStore.Services.Clientes.Queries.ObterListaClientesPorNomeParcial;
using MelStore.Services.Pedidos.Commands.CreatePedido;
using MelStore.Services.Pedidos.Queries.ObterListaPedido;
using MelStore.Services.Pedidos.Queries.ObterPedidoPorId;
using MelStore.Services.Produtos.Commands.CreateProduto;
using MelStore.Services.Produtos.Commands.UpdateProduto;
using MelStore.Services.Produtos.Queries.ObterListaProduto;
using MelStore.Services.Produtos.Queries.ObterListaProdutosPorNomeParcial;
using MelStore.Services.Produtos.Queries.ObterProdutoPorId;
using MelStore.Services.Validators;
using Microsoft.EntityFrameworkCore;

namespace MelStore.Extensions
{
  public static class ServiceExtensions
  {
    public static void ConfigureLoggerService(this IServiceCollection services) => services.AddScoped<ILoggerManager, LoggerManager>();

    public static void ConfigureDateProvider(this IServiceCollection services) => services.AddScoped<IDateProvider, DateProvider>();

    public static void ConfigureCors(this IServiceCollection services) =>
     services.AddCors(options =>
     {
       options.AddPolicy("CorsPolicy", builder =>
       builder.AllowAnyOrigin()
       .AllowAnyMethod()
       .AllowAnyHeader());
     });

    public static void ConfigureFluentValidator(this IServiceCollection services)
    {
      services.AddTransient<IValidator<Pedido>, PedidoValidator>();
      services.AddTransient<IValidator<Cliente>, ClienteValidator>();
      services.AddTransient<IValidator<Produto>, ProdutoValidator>();
      services.AddTransient<IValidator<ItemPedido>, ItemPedidoValidator>();
    }

    public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
      services.AddDbContext<RepositoryContext>(opts =>
        opts.UseNpgsql(configuration.GetConnectionString("PostgresqlConnection")));

    public static void ConfigureRepositoryManager(this IServiceCollection services) =>
      services.AddScoped<IRepositoryManager, RepositoryManager>();

    public static void ConfigureCommandsAndQueries(this IServiceCollection services)
    {
      services.AddScoped<IObterListaClienteQuery, ObterListaClienteQuery>();
      services.AddScoped<IObterClientePorIdQuery, ObterClientePorIdQuery>();
      services.AddScoped<IObterListaClientesPorNomeParcialQuery, ObterListaClientesPorNomeParcialQuery>();
      services.AddScoped<ICreateClienteCommand, CreateClienteCommand>();      
      services.AddScoped<IUpdateClienteCommand, UpdateClienteCommand>();
      services.AddScoped<IObterListaProdutosPorNomeParcialQuery, ObterListaProdutosPorNomeParcialQuery>();      

      services.AddScoped<IObterListaProdutoQuery, ObterListaProdutoQuery>();
      services.AddScoped<IObterProdutoPorIdQuery, ObterProdutoPorIdQuery>();
      services.AddScoped<ICreateProdutoCommand, CreateProdutoCommand>();
      services.AddScoped<IUpdateProdutoCommand, UpdateProdutoCommand>();

      services.AddScoped<ICreatePedidoCommand, CreatePedidoCommand>();
      services.AddScoped<IObterListaPedidoQuery, ObterListaPedidoQuery>();
      services.AddScoped<IObterPedidoPorIdQuery, ObterPedidoPorIdQuery>();
    }
  }
}
