using Microsoft.AspNetCore.Mvc;

namespace lgblesson13Layout.Controllers
{
    public class LgbProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(string keyword)
        {
            ViewData["keyword"] = keyword;
            return View();
        }

        public IActionResult Hots()
        {
            return View();
        }
    }
}
