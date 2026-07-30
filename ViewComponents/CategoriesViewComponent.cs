using Microsoft.AspNetCore.Mvc;
using WebApplication.Entities; // переконайся, що простір імен збігається з твоїм проєктом

namespace WebApplication.ViewComponents
{
    // Назва класу має закінчуватися на ViewComponent
    public class CategoriesViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Це твої дані (пункт 1 твого завдання)
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Культура" },
                new Category { Id = 2, Name = "Бізнес" },
                new Category { Id = 3, Name = "Спорт" },
                new Category { Id = 4, Name = "Технології" }
            };

            return View(categories);
        }
    }
}