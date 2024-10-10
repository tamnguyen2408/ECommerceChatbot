using ECommerceChatbot.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerceChatbot.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.RegisterAsync(model.UserName, model.Email, model.Password, model.ConfirmPassword, model.Phone);
                if (result == "User registered successfully!")
                {
                    return RedirectToAction("Login");
                }
                ModelState.AddModelError("", result);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.LoginAsync(model.UserName, model.Password, model.Role);
                if (result == "Login successful!")
                {
                    // Check the role and redirect to respective index pages
                    if (model.Role == "admin")
                    {
                        return RedirectToAction("Index", "Admin"); // Admin dashboard
                    }
                    else if (model.Role == "user")
                    {
                        return RedirectToAction("Index", "User"); // User dashboard
                    }
                }
                ModelState.AddModelError("", result);
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(); // Clear the user session
            return RedirectToAction("Index", "Home"); // Redirect to the home page or login page
        }

    }
}
