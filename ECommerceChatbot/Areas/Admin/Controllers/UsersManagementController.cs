using Microsoft.AspNetCore.Mvc;
using ECommerceChatbot.Models; // Đường dẫn đến model User
using System.Linq;
using ECommerceChatbot.Data;

namespace ECommerceChatbot.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/UsersManagement")]
    public class UsersManagementController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersManagementController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/UsersManagement/Index
        [Route("Index")]
        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            return View(users);
        }

        // GET: Admin/UsersManagement/Create
        [Route("AddUser")]
        public IActionResult AddUser()
        {
            return View();
        }

        // POST: Admin/UsersManagement/Create
        [HttpPost]
        [Route("AddUser")]
        [ValidateAntiForgeryToken]
        public IActionResult AddUser([Bind("UserID,UserName,Email,Password,Phone,Role")] User user)
        {
            if (ModelState.IsValid)
            {
                // Thêm user vào database
                _context.Users.Add(user);
                _context.SaveChanges();

                // Chuyển hướng về trang Index sau khi thêm thành công
                return RedirectToAction("Index");
            }

            // Nếu dữ liệu không hợp lệ, trả về lại trang AddUser
            return View(user);
        }


        // GET: Admin/UsersManagement/Edit/{id}
        [Route("Edit/{id}")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Admin/UsersManagement/Edit/{id}
        [HttpPost]
        [Route("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("UserID,UserName,Email,Password,Phone,Role")] User user)
        {
            if (id != user.UserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Admin/UsersManagement/Delete/{id}
        [Route("Delete/{id}")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Admin/UsersManagement/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [Route("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
