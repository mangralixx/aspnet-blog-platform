using Microsoft.AspNetCore.Mvc;
using WebApplication.Entities;

namespace WebApplication.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            // Створюємо список об'єктів MenuItem
            var model = new List<MenuItem>
            {
                new MenuItem { Title = "Електроніка", Children = new List<MenuItem>
                {
                    new MenuItem { Title = "Смартфони", Children = new List<MenuItem>
                    {
                        new MenuItem { Title = "Apple" },
                        new MenuItem { Title = "Samsung" }
                    }},
                    new MenuItem { Title = "Ноутбуки" }
                }},
                new MenuItem { Title = "Стиль життя", Children = new List<MenuItem>
                {
                    new MenuItem { Title = "Подорожі" },
                    new MenuItem { Title = "Здоров'я" }
                }}
            };

            return View(model);
        }
    }
}