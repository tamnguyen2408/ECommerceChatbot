using Microsoft.AspNetCore.Mvc;

namespace ECommerceChatbot.Areas.Admin.Controllers
{
    [Area("Admin")] // "Admin" should be case-sensitive as it matches the folder name
    [Route("Admin/UsersManagement")] // Use placeholder for better structure
    public class UsersManagement : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
