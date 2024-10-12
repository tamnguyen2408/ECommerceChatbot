using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerceChatbot.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "User name is required")]
        [StringLength(100, ErrorMessage = "User name cannot exceed 100 characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "Password cannot exceed 100 characters")]
        public string Password { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; }

        // Navigation property for ChatbotInteractions
        public ICollection<ChatbotInteraction> ChatbotInteractions { get; set; }
    }
}
