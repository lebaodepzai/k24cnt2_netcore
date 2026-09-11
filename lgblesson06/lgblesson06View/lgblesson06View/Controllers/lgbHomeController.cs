using System.Diagnostics;
using lgblesson06View.Models;
using Microsoft.AspNetCore.Mvc;

namespace lgblesson06View.Controllers
{
    public class lgbHomeController : Controller
    {
        private readonly ILogger<lgbHomeController> _logger;

        public lgbHomeController(ILogger<lgbHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
