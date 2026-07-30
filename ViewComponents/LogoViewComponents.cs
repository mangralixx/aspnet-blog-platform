using Microsoft.AspNetCore.Mvc;

namespace WebApplication.ViewComponents
{
    public class LogoViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
       
            return View();
        }
    }
}