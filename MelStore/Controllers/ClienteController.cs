using MelStore.Services.Clientes.Commands.CreateCliente;
using MelStore.Services.Clientes.Commands.UpdateCliente;
using MelStore.Services.Clientes.Queries;
using MelStore.Services.Clientes.Queries.ObterClientePorId;
using MelStore.Services.Clientes.Queries.ObterListaCliente;
using Microsoft.AspNetCore.Mvc;

namespace MelStore.Controllers
{
  public class ClienteController : Controller
  {
    private readonly IObterListaClienteQuery obterListaClienteQuery;
    private readonly IObterClientePorIdQuery obterClientePorIdQuery;
    private readonly ICreateClienteCommand createClienteCommand;
    private readonly IUpdateClienteCommand updateClienteCommand;

    public ClienteController(
      IObterListaClienteQuery obterListaClienteQuery,
      IObterClientePorIdQuery obterClientePorIdQuery,
      ICreateClienteCommand createClienteCommand,
      IUpdateClienteCommand updateClienteCommand
      )
    {
      this.obterListaClienteQuery = obterListaClienteQuery;
      this.createClienteCommand = createClienteCommand;
      this.obterClientePorIdQuery = obterClientePorIdQuery;
      this.updateClienteCommand = updateClienteCommand;
    }

    public async Task<IActionResult> Index()
    {
      var clientes = await obterListaClienteQuery.ExecuteAsync();
      return View(clientes ?? Array.Empty<ClienteModel>());
    }

    public IActionResult Add()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(ClienteForCreationModel model)
    {
      if (ModelState.IsValid)
      {
        var result = await createClienteCommand.ExecuteAsync(model);
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
      var cliente = await obterClientePorIdQuery.ExecuteAsync(id);

      if (cliente == null) return RedirectToAction("index");

      return View(cliente);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ClienteForEditionModel model)
    {
      if (ModelState.IsValid)
      {
        var result = await updateClienteCommand.ExecuteAsync(model);
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
  }
}
