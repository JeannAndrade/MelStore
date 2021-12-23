using MelStore.Services.Pedidos.Commands.CreatePedido;
using MelStore.Services.Pedidos.Queries.ObterListaPedido;
using MelStore.Services.Pedidos.Queries.ObterPedidoPorId;
using Microsoft.AspNetCore.Mvc;

namespace MelStore.Controllers
{
  public class PedidoController : Controller
  {
    private readonly ICreatePedidoCommand createPedidoCommand;
    private readonly IObterListaPedidoQuery obterListaPedidoQuery;
    private readonly IObterPedidoPorIdQuery obterPedidoPorIdQuery;

    public PedidoController(ICreatePedidoCommand createPedidoCommand, IObterListaPedidoQuery obterListaPedidoQuery, IObterPedidoPorIdQuery obterPedidoPorIdQuery)
    {
      this.createPedidoCommand = createPedidoCommand;
      this.obterListaPedidoQuery = obterListaPedidoQuery;
      this.obterPedidoPorIdQuery = obterPedidoPorIdQuery;
    }

    public async Task<IActionResult> Index()
    {
      var pedidos = await obterListaPedidoQuery.ExecuteAsync();
      return View(pedidos);
    }

    public IActionResult Add()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(PedidoForCreationModel pedidoModel)
    {
      if (ModelState.IsValid)
      {
        var result = await createPedidoCommand.ExecuteAsync(pedidoModel);
        if (!result.IsValid)
        {
          result.Errors.ForEach(error => ModelState.AddModelError(String.Empty, error.ErrorMessage));
          return View();
        }
        return RedirectToAction("index");
      }
      else
        return View();
    }
  
    public async Task<IActionResult> Edit(int id)
    {
      var pedido = await obterPedidoPorIdQuery.ExecuteAsync(id);
      return View(pedido);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id)
    {
      var pedido = await obterPedidoPorIdQuery.ExecuteAsync(id);
      return View(pedido);
    }

  }
}
