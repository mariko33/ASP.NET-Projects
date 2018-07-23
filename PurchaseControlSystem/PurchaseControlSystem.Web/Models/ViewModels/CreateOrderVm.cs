using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PurchaseControlSystem.Models.EntityModels;
using PurchaseControlSystem.Models.Enums;

namespace PurchaseControlSystem.Web.Models.ViewModels
{
    public class CreateOrderVm
    {
        public CreateOrderVm()
        {
            this.Customers = new List<Customer>();
        }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [NotMapped]
        public decimal TotalAmount => this.Price * this.Quantity;
       
        public Status Status { get; set; }
        public int CustomerId { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}