using Microsoft.AspNetCore.Mvc;

namespace ECommerceChatbot.Areas.Admin.Controllers
{
    [Area("Admin")] // "Admin" should be case-sensitive as it matches the folder name
    [Route("Admin/OrderManagement")] // Use placeholder for better structure
    public class OrderManagementController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
