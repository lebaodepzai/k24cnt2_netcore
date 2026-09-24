using Microsoft.AspNetCore.Mvc;
using lgblesson09Annotation.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace lgblesson09Annotation.Controllers
{
    public class LgbProductController : Controller
    {
        private static List<LgbProduct> _products = new List<LgbProduct>
        {
            new LgbProduct { Id = 1, Name = "Laptop Dell XPS 15", Price = 35000000, Stock = 10, CreatedAt = new DateTime(2024, 1, 15), Image = "dell-xps.png" },
            new LgbProduct { Id = 2, Name = "iPhone 15 Pro Max", Price = 30000000, Stock = 25, CreatedAt = new DateTime(2024, 2, 20), Image = "iphone15.png" },
            new LgbProduct { Id = 3, Name = "Bàn phím cơ Logi MX Keys", Price = 2500000, Stock = 50, CreatedAt = new DateTime(2024, 3, 10), Image = "logi-keys.png" }
        };

        public IActionResult Index()
        {
            return View(_products);
        }

        public IActionResult Create()
        {
            return View(new LgbProduct());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LgbProduct model)
        {
            if (ModelState.IsValid)
            {
                model.Id = _products.Count > 0 ? _products.Max(p => p.Id) + 1 : 1;
                _products.Add(model);
                TempData["SuccessMessage"] = "Thêm sản phẩm thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
