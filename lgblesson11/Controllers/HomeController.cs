using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lgb2410900009_exam.Models;

namespace Lgb2410900009_exam.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // Action LgbAbout
        [Route("LgbAbout")]
        [Route("Home/LgbAbout")]
        public IActionResult LgbAbout()
        {
            ViewBag.StudentId = "2410900009";
            ViewBag.StudentName = "Lê Gia Bảo";
            ViewBag.Class = "K24CNT2";
            ViewBag.Email = "lebaoo22022006@gmail.com";
            ViewBag.Phone = "0912345678";
            ViewBag.Course = "Lập trình .NET Core MVC";
            ViewBag.School = "Trường Đại Học Nguyễn Trãi";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
