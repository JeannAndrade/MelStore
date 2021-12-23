using AutoMapper;
using MelStore.Core.Models;
using MelStore.Services.Clientes.Queries;
using MelStore.Services.Pedidos.Queries.ObterListaPedido;
using MelStore.Services.Pedidos.Queries.ObterPedidoPorId;
using MelStore.Services.Produtos.Queries;

namespace MelStore.Infraetructure.Mappings
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<Cliente, ClienteModel>();
      CreateMap<Produto, ProdutoModel>();

      CreateMap<DateTime, string>().ConvertUsing(s => s.ToString("dd-MM-yyyy HH:mm"));

      CreateMap<Pedido, PedidoForListModel>()
        .ForMember(dest => dest.NomeCliente, opt => opt.MapFrom(src => src.Cliente.Nome))
        .ForMember(dest => dest.QuantidadeItens, opt => opt.MapFrom(src => src.ItemPedidos.Count))
        .ForMember(dest => dest.ValorTotal, opt => opt.MapFrom(src => src.ItemPedidos.Sum(s => s.PrecoUnitario)));

      CreateMap<Pedido, PedidoModel>()
        .ForMember(dest => dest.NomeCliente, opt => opt.MapFrom(src => src.Cliente.Nome))
        .ForMember(dest => dest.ItensPedido, opt => opt.MapFrom(src => src.ItemPedidos));

      CreateMap<ItemPedido, ItemPedidoForCreationModel>()
        .ForMember(dest => dest.NomeProduto, opt => opt.MapFrom(src => src.Produto.Nome))
        .ForMember(dest => dest.PrecoUnitario, opt => opt.MapFrom(src => String.Format("{0:C2}", src.PrecoUnitario)))
        .ForMember(dest => dest.Quantidade, opt => opt.MapFrom(src => src.Quantidade));
    }
  }

}
