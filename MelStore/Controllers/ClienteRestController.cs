using MelStore.Services.Clientes.Queries.ObterListaClientesPorNomeParcial;
using Microsoft.AspNetCore.Mvc;

namespace MelStore.Controllers
{
  [Route("api/cliente")]
  public class ClienteRestController : Controller
  {
    private readonly IObterListaClientesPorNomeParcialQuery obterListaClientesPorNomeParcialQuery;

    public ClienteRestController(IObterListaClientesPorNomeParcialQuery obterListaClientesPorNomeParcialQuery)
    {
      this.obterListaClientesPorNomeParcialQuery = obterListaClientesPorNomeParcialQuery;
    }

    [Produces("application/json")]
    [HttpGet("search")]
    public async Task<IActionResult> Search()
    {
      try
      {
        string term = HttpContext.Request.Query["term"].ToString();
        var clientes = await obterListaClientesPorNomeParcialQuery.ExecuteAsync(term);
        var nomes = clientes.Select(c => c.Nome).ToList();
        return Ok(nomes);
      }
      catch
      {
        return BadRequest();
      }
    }
  }
}
