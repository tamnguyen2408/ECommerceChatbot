using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerceChatbot.Models
{
    public class Cart
    {
        [Key]
        public int CartID { get; set; }

        [Required]
        public int UserID { get; set; }

        // Navigation property for CartItems
        public ICollection<CartItem> CartItems { get; set; }
    }
}
