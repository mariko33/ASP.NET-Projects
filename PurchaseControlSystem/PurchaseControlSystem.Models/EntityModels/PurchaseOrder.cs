using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PurchaseControlSystem.Models.Enums;

namespace PurchaseControlSystem.Models.EntityModels
{
    public class PurchaseOrder
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public Status Status { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        [NotMapped]
        public decimal TotalAmount => this.Price * this.Quantity;

    }
}