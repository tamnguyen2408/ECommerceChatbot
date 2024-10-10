using Microsoft.AspNetCore.Mvc;

namespace ECommerceChatbot.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
