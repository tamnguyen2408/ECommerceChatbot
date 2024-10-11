using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceChatbot.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }

        [Required]
        [StringLength(200)] // Set max length for product name
        public string Name { get; set; }

        [StringLength(500)] // Optional: Set max length for description
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")] // Specify column type
        public decimal Price { get; set; }

        public int Stock { get; set; } // Quantity in stock

        // Navigation property for ProductCategories
        public ICollection<ProductCategories> Categories { get; set; }

        // Navigation property for OrderItems
        public ICollection<OrderItem> OrderItems { get; set; }

        // Navigation property for CartItems
        public ICollection<CartItem> CartItems { get; set; }
    }
}
