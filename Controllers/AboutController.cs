    using Microsoft.AspNetCore.Mvc;
using WebApplication.Entities;
namespace WebApplication.Controllers
{

    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult ContactUs()
        {
            return View();
        }



        //public ViewResult SaveClientMessage(string name, string email, string subdject, string message) {}

        [HttpPost]
        public IActionResult SaveClientMessage(ClientMessage clientMessage)
        {
            if (!ModelState.IsValid)
            {
                return View("ContactUs", clientMessage);
            }

            // TODO: сохранить в БД

            return RedirectToAction(nameof(MessageSaved), new { name = clientMessage.UserName });
        }

        [HttpGet]
        public IActionResult MessageSaved(string name)
        {
            return View(model: name);
        }
    }
}