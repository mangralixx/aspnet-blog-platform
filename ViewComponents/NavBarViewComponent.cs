using Microsoft.AspNetCore.Mvc;
using WebApplication.Entities;


namespace WebApplication.ViewComponents
{
    public class NavBarViewComponent : ViewComponent
    {
        private List<Navigate> _navigates;

        public NavBarViewComponent()
        {
            _navigates = new List<Navigate>();

            // Додаємо пункт "Home"
            _navigates.Add(new Navigate()
            {
                Id = 1,
                Title = "Home",
                Href = "/",
                Order = 1,
                ParentId = null
            });

            // Створюємо батьківський пункт "About"
            Navigate about = new Navigate()
            {
                Id = 2,
                Title = "About",
                Href = "/about",
                Order = 2,
                ParentId = null
            };

            // Додаємо вкладені елементи (Childs)
            about.Childs.Add(new Navigate()
            {
                Id = 3,
                Title = "About us",
                Href = "/about",
                Order = 1,
                ParentId = 2
            });

            about.Childs.Add(new Navigate()
            {
                Id = 4, // Рекомендую поставити 4, щоб ID були унікальними
                Title = "Contact us",
                Href = "/about/contactus",
                Order = 2,
                ParentId = 2
            });

            // Додаємо "About" разом з його дітьми до загального списку
            _navigates.Add(about);
        }

        public IViewComponentResult Invoke()
        {
            // Повертає файл NavBar.cshtml з даними списку
            return View("NavBar", _navigates);
        }
    }
}