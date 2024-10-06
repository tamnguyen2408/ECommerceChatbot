using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceChatbot.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemID { get; set; }

        [Required]
        public int OrderID { get; set; }

        [Required]
        public int ProductID { get; set; }

        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18,2)")] // Specify column type
        public decimal Price { get; set; } // Price at the time of order

        // Navigation property for Order
        public Order Order { get; set; }

        // Navigation property for Product
        public Product Product { get; set; }
    }
}
