using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceChatbot.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        [Required]
        public int OrderID { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")] // Specify column type
        public decimal Amount { get; set; }

        [Required]
        public string PaymentMethod { get; set; } // e.g., Credit Card, PayPal, etc.

        public DateTime PaymentDate { get; set; }

        // Navigation property for Order
        public Order Order { get; set; }
    }
}
