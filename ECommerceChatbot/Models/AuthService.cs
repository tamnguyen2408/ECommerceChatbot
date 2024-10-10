using ECommerceChatbot.Data;
using ECommerceChatbot.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ECommerceChatbot.Models
{
    public class AuthService
    {
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Register method
        public async Task<string> RegisterAsync(string username, string email, string password, string confirmPassword, string phone)
        {
            if (password != confirmPassword)
            {
                return "Passwords do not match.";
            }

            var userExists = await _context.Users.AnyAsync(u => u.Email == email);
            if (userExists)
            {
                return "User already exists with this email.";
            }

            var newUser = new User
            {
                UserName = username,
                Email = email,
                Password = password, // Ensure password hashing in production
                Phone = phone,
                Role = "user" // Default role to "user"
            };

            try
            {
                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Logging or error handling
                return "An error occurred while registering the user.";
            }

            return "User registered successfully!";
        }
        // Login method
        public async Task<string> LoginAsync(string username, string password, string role)
        {
            var user = await _context.Users
                                     .FirstOrDefaultAsync(u => u.UserName == username && u.Password == password && u.Role == role);
            if (user != null)
            {
                return "Login successful!";
            }
            return "Invalid username, password, or role.";
        }

    }
}
