using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LgbLesson08Models.Models;

namespace LgbLesson08Models.Controllers
{
    public class LgbHomeController : Controller
    {
        private readonly ILogger<LgbHomeController> _logger;

        public LgbHomeController(ILogger<LgbHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult LgbIndex()
        {
            ViewData["Title"] = "Trang chủ - LgbLesson08Models";
            return View();
        }

        public IActionResult LgbAbout()
        {
            ViewData["Title"] = "Thông tin cá nhân / Dự án";
            return View();
        }

        public IActionResult LgbPrivacy()
        {
            ViewData["Title"] = "Chính sách bảo mật";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
