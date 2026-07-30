using Microsoft.AspNetCore.Mvc;
using WebApplication.Entities;

namespace WebApplication.Controllers
{
    public class ContactController : Controller
    {
        // Этот метод открывает саму форму
        [HttpGet]
        public IActionResult Index()
        {
            // У тебя файл называется ContactUS (две большие буквы)
            return View("ContactUS");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveClientMessage(ClientMessage clientMessage)
        {
            if (!ModelState.IsValid)
            {
                // Повертає ту саму сторінку з алертом
                return View("ContactUS", clientMessage);
            }

            // Тут додається збереження в базу

            // Перенаправлення на метод Success
            return RedirectToAction(nameof(Success), new { name = clientMessage.UserName });
        }

        [HttpGet]
        public IActionResult Success(string name)
        {
            // Шукає файл Success.cshtml
            return View("Success", model: name);
        }
    }
}