using Microsoft.AspNetCore.Mvc;
using WebApplication.Entities;

namespace WebApplication.ViewComponents
{
    public class NavMenuViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Імітуємо отримання даних (наприклад, з БД або статичний список)
            var menuItems = new List<MenuItem>
            {
                new MenuItem { Title = "Головна", Url = "/" },
                new MenuItem { Title = "Про нас", Url = "/Home/About" },
                new MenuItem { Title = "Категорії", Url = "#", Children = new List<MenuItem> {
                    new MenuItem { Title = "Культура", Url = "/Category/Culture" },
                    new MenuItem { Title = "Бізнес", Url = "/Category/Business" }
                }},
                new MenuItem { Title = "Контакти", Url = "/Contact" }
            };

            return View(menuItems);
        }
    }
}