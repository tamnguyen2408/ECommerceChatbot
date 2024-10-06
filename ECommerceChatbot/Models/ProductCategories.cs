using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerceChatbot.Models
{
    public class ProductCategories
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(100)] // Set max length for category name
        public string CategoryName { get; set; }

        // Navigation property for Products
        public ICollection<Product> Products { get; set; }
    }
}
