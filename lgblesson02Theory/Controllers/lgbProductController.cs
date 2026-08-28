using lgblesson02Theory.Models;
using Microsoft.AspNetCore.Mvc;

namespace lgblesson02Theory.Controllers
{
    public class lgbProductController : Controller
    {
        public IActionResult LgbIndex()
        {
            // dữ liệu trong đối tượng : ViewBag, ViewData, TemData
            ViewBag.name = "Lê Gia Bảo";
            ViewData["productVD"] = "Laptop Dell Vostro";
            TempData["UNI"] = "Trường Đại học Nguyễn Trãi - NTU";
            return View();
        }
        public IActionResult GetProduct()
        {
            // tạo mock data product
            lgbProduct lgbProduct = new lgbProduct()
            {
                ProductID = "2410900009",
                ProductName = "Lê Gia Bảo",
                YearRelease = 2006,
                Price = 1000
            };

            ViewBag.product = lgbProduct;
            ViewData["product"] = lgbProduct;

            return View("product");
        }
    }
}
