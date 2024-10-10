using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerceChatbot.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [StringLength(100)] // Set max length for username
        public string UserName { get; set; }

        [Required]
        [EmailAddress] // Validate email format
        public string Email { get; set; }

        [Required]
        [StringLength(100)] // Set max length for password
        public string Password { get; set; }

        [Phone] // Validate phone number format
        public string Phone { get; set; }
        [Required]
        public string Role { get; set; }

        // Navigation property for ChatbotInteractions
        public ICollection<ChatbotInteraction> ChatbotInteractions { get; set; }
    }
}
