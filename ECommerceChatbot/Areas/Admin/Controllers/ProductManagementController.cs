using Microsoft.AspNetCore.Mvc;

namespace ECommerceChatbot.Areas.Admin.Controllers
{
    [Area("Admin")] // "Admin" should be case-sensitive as it matches the folder name
    [Route("Admin/ProductManagement")] // Use placeholder for better structure
    public class ProductManagementController : Controller
    {
        [Route("Index")] // Maps to the Index action or leave it if default action
        public IActionResult Index()
        {
            return View();
        }
    }
}
