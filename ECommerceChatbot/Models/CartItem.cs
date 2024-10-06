using System.ComponentModel.DataAnnotations;

namespace ECommerceChatbot.Models
{
    public class CartItem
    {
        [Key]
        public int CartItemID { get; set; }

        [Required]
        public int CartID { get; set; }

        [Required]
        public int ProductID { get; set; }

        public int Quantity { get; set; }

        // Navigation property for Cart
        public Cart Cart { get; set; }

        // Navigation property for Product
        public Product Product { get; set; }
    }
}
