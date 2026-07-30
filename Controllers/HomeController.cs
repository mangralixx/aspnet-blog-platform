using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        // Головна сторінка (index.html у твоєму старому коді)
        public IActionResult Index()
        {
            return View();
        }

        // Сторінка "Про нас" (замість about.html)
        public IActionResult About()
        {
            return View();
        }

        // Сторінка одного посту (замість single-post.html)
        public IActionResult SinglePost()
        {
            return View();
        }

        // Сторінка приватності (стандартна для ASP.NET)
        public IActionResult Privacy()
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