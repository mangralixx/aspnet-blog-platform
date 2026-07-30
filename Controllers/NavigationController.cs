using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication.Entities;

namespace WebApplication.Controllers
{
    public class NavigationController : Controller
    {
        public IActionResult Index()
        {
            // Створюємо структуру категорій (меню)
            var categories = new List<MenuItem>
            {
                new MenuItem
                {
                    Title = "Техніка",
                    Url = "/tech",
                    Children = new List<MenuItem>
                    {
                        new MenuItem { Title = "Смартфони", Url = "/tech/phones",
                            Children = new List<MenuItem> {
                                new MenuItem { Title = "Apple", Url = "/tech/phones/apple" },
                                new MenuItem { Title = "Samsung", Url = "/tech/phones/samsung" }
                            }
                        },
                        new MenuItem { Title = "Ноутбуки", Url = "/tech/laptops" }
                    }
                },
                new MenuItem
                {
                    Title = "Одяг",
                    Url = "/fashion",
                    Children = new List<MenuItem>
                    {
                        new MenuItem { Title = "Чоловічий", Url = "/fashion/men" },
                        new MenuItem { Title = "Жіночий", Url = "/fashion/women" }
                    }
                }
            };

            return View(categories);
        }
    }
}