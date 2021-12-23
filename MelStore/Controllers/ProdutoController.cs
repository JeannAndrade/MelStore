using MelStore.Services.Produtos.Commands.CreateProduto;
using MelStore.Services.Produtos.Commands.UpdateProduto;
using MelStore.Services.Produtos.Queries;
using MelStore.Services.Produtos.Queries.ObterListaProduto;
using MelStore.Services.Produtos.Queries.ObterProdutoPorId;
using Microsoft.AspNetCore.Mvc;

namespace MelStore.Controllers
{
  public class ProdutoController : Controller
  {
    private readonly IObterListaProdutoQuery obterListaProdutoQuery;
    private readonly IObterProdutoPorIdQuery obterProdutoPorIdQuery;
    private readonly ICreateProdutoCommand createProdutoCommand;
    private readonly IUpdateProdutoCommand updateProdutoCommand;

    public ProdutoController(
      IObterListaProdutoQuery obterListaProdutoQuery,
      IObterProdutoPorIdQuery obterProdutoPorIdQuery,
      ICreateProdutoCommand createProdutoCommand,
      IUpdateProdutoCommand updateProdutoCommand
      )
    {
      this.obterListaProdutoQuery = obterListaProdutoQuery;
      this.createProdutoCommand = createProdutoCommand;
      this.obterProdutoPorIdQuery = obterProdutoPorIdQuery;
      this.updateProdutoCommand = updateProdutoCommand;
    }

    public async Task<IActionResult> Index()
    {
      var produtos = await obterListaProdutoQuery.ExecuteAsync();
      return View(produtos ?? Array.Empty<ProdutoModel>());
    }

    public IActionResult Add()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(ProdutoForCreationModel model)
    {
      if (ModelState.IsValid)
      {
        var result = await createProdutoCommand.ExecuteAsync(model);
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
      var produto = await obterProdutoPorIdQuery.ExecuteAsync(id);

      if (produto == null) return RedirectToAction("index");

      return View(produto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ProdutoForEditionModel model)
    {
      if (ModelState.IsValid)
      {
        var result = await updateProdutoCommand.ExecuteAsync(model);
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
