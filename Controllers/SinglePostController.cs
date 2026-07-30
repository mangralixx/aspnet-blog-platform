using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{

    public class SinglePostController : Controller
    {

        public IActionResult SinglePost(int id)
        {
            ViewBag.PostId = id;
            return View();
        }
    }
}