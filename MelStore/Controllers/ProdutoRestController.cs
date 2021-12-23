using MelStore.Services.Produtos.Queries.ObterListaProdutosPorNomeParcial;
using Microsoft.AspNetCore.Mvc;

namespace MelStore.Controllers
{
  [Route("api/produto")]
  public class ProdutoRestController : Controller
  {
    private readonly IObterListaProdutosPorNomeParcialQuery obterListaProdutosPorNomeParcialQuery;

    public ProdutoRestController(IObterListaProdutosPorNomeParcialQuery obterListaProdutosPorNomeParcialQuery)
    {
      this.obterListaProdutosPorNomeParcialQuery = obterListaProdutosPorNomeParcialQuery;
    }

    [Produces("application/json")]
    [HttpGet("search")]
    public async Task<IActionResult> Search()
    {
      try
      {
        string term = HttpContext.Request.Query["term"].ToString();
        var produtos = await obterListaProdutosPorNomeParcialQuery.ExecuteAsync(term);
        var nomes = produtos.Select(c => c.Nome).ToList();
        return Ok(nomes);
      }
      catch
      {
        return BadRequest();
      }
    }
  }
}