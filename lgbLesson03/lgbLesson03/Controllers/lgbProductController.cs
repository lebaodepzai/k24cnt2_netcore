using lgbLesson03.Models;
using Microsoft.AspNetCore.Mvc;

namespace lgbLesson03.Controllers
{
    [Route("/danh-sach-san-pham")]
    public class lgbProductController : Controller
    {
        //mock data
        private readonly List<lgbProduct> _products = new()
        {
            new lgbProduct
            {
            lgbProductId = "ELEC001",
            lgbProductName = "iPhone 15 Pro Max 256GB",
            lgbYearRelease = 2023,
            lgbPrice = 29990000m
            },
            new lgbProduct
            {
            lgbProductId = "ELEC002",
            lgbProductName = "Samsung Galaxy S24 Ultra 512GB",
            lgbYearRelease = 2024,
            lgbPrice = 33990000m
            },
            new lgbProduct
            {
            lgbProductId = "ELEC003",
            lgbProductName = "MacBook Pro 14 inch M3 Pro",
            lgbYearRelease = 2023,
            lgbPrice = 49990000m
            },
            new lgbProduct
            {
            lgbProductId = "ELEC004",
            lgbProductName = "Dell XPS 16 9640 Core Ultra 7",
            lgbYearRelease = 2024,
            lgbPrice = 52500000m
            },
            new lgbProduct
            {
            lgbProductId = "ELEC005",
            lgbProductName = "iPad Air 6 M2 11 inch Wi-Fi 128GB",
            lgbYearRelease = 2024,
            lgbPrice = 16990000m
            },
            new lgbProduct
            {
            lgbProductId = "ELEC006",
            lgbProductName = "Sony WH-1000XM5 Wireless Headphones",
            lgbYearRelease = 2022,
            lgbPrice = 8490000m
            },
            new lgbProduct
            {
            lgbProductId = "ELEC007",
            lgbProductName = "LG OLED evo C3 65 inch 4K TV",
            lgbYearRelease = 2023,
            lgbPrice = 38900000m
            },
            new lgbProduct
            {
            lgbProductId = "ELEC008",
            lgbProductName = "Apple Watch Series 9 GPS 45mm",
            lgbYearRelease = 2023,
            lgbPrice = 10490000m
            },
            new lgbProduct
            {
            lgbProductId = "ELEC009",
            lgbProductName = "Asus ROG Ally X Handheld Gaming PC",
            lgbYearRelease = 2024,
            lgbPrice = 23990000m
            },
            new lgbProduct
            {
            lgbProductId = "ELEC010",
            lgbProductName = "PlayStation 5 Slim Digital Edition",
            lgbYearRelease = 2023,
            lgbPrice = 11990000m
            }

        };
        public IActionResult Index()
        {

            return Json(_products);
        }

        // collection => view
        [Route("all")]
        public IActionResult lgbGetAllProduct()
        {
            ViewData["product"] = _products;
            return View();
        }
    }
}
