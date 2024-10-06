namespace ECommerceChatbot.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;  // Add this using for data annotations

    public class ChatbotInteraction
    {
        [Key] // Optional: Use if you want to explicitly define the primary key
        public int InteractionID { get; set; }

        [Required] // Ensures UserID cannot be null
        public int UserID { get; set; }

        [Required] // Ensures Query cannot be null
        [StringLength(500)] // Optional: Set maximum length for the query
        public string Query { get; set; }

        [Required] // Ensures Response cannot be null
        [StringLength(1000)] // Optional: Set maximum length for the response
        public string Response { get; set; }

        public DateTime CreatedAt { get; set; }

        // Navigation property for User
        public User User { get; set; }
    }
}
