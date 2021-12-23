using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MelStore.Brokers.LoggerBrokers;
using Microsoft.AspNetCore.Mvc;

namespace MelStore.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILoggerManager _loggerManager;
    public HomeController(ILoggerManager loggerManager)
    {
      _loggerManager = loggerManager;
    }
    public IActionResult Index() => View();
  }
}