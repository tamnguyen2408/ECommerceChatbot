using ECommerceChatbot.Data;
using ECommerceChatbot.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceChatbot.Areas.Admin.Controllers
{
    [Area("Admin")] // "Admin" should be case-sensitive as it matches the folder name
    [Route("Admin/ProductManagement")] // Use placeholder for better structure
    public class ProductManagement : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductManagement(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("Index")] // Maps to the Index action or leave it if default action
        public IActionResult Index()
        {
            var products = _context.Products.ToList(); // Lấy danh sách sản phẩm từ database
            return View(products);
        }
        [HttpGet]
        [Route("AddProduct")]
        public IActionResult AddProduct()
        {
            return View();
        }

        // Xử lý khi người dùng gửi form thêm sản phẩm
        [HttpPost]
        [Route("AddProduct")]
        public IActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product); // Thêm sản phẩm mới vào database
                _context.SaveChanges(); // Lưu thay đổi
                return RedirectToAction("Index"); // Chuyển hướng về trang danh sách sản phẩm
            }
            else
            {
                // In lỗi ra để kiểm tra
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }

            return View(product); // Nếu có lỗi, hiển thị lại form
        }

    }
}
