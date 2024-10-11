using Microsoft.AspNetCore.Mvc;

namespace ECommerceChatbot.Areas.Admin.Controllers
{
    [Area("Admin")] // "Admin" should be case-sensitive as it matches the folder name
    [Route("Admin/ViewSalesReports")] // Use placeholder for better structure
    public class ViewSalesReports : Controller
    {
        [Route("ViewSalesReportsByDay")]
        public IActionResult ViewSalesReportsByDay()
        {
            return View();
        }
        [Route("ViewSalesReportsByMonth")]
        public IActionResult ViewSalesReportsByMonth()
        {
            return View();
        }
        [Route("ViewSalesReportsByYear")]
        public IActionResult ViewSalesReportsByYear()
        {
            return View();
        }
    }
}
