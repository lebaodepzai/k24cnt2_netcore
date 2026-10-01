using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lgblesson12.Entities;
using lgblesson12.Models;

namespace lgblesson12.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var banners = await _context.Banners.Where(b => b.Status == 1).ToListAsync();
            var products = await _context.Products.Include(p => p.Category).Where(p => p.Status == 1).ToListAsync();

            ViewBag.Banners = banners;
            return View(products);
        }

        public async Task<IActionResult> Product()
        {
            var products = await _context.Products.Include(p => p.Category).ToListAsync();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.CurrentThreadId.ToString() });
        }
    }
}
