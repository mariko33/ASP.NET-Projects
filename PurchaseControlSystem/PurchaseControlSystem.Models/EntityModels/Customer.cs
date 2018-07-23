using System.Collections.Generic;
using System.ComponentModel;
using PurchaseControlSystem.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseControlSystem.Models.EntityModels
{
    public class Customer
    {
        public Customer()
        {
            this.Orders = new HashSet<PurchaseOrder>();
        }

        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public Sex Sex { get; set; }

        public string Telephone { get; set; }

        public Status Status { get; set; }

        public ICollection<PurchaseOrder> Orders { get; set; }

        [NotMapped]
        public string FullName => $"{this.FirstName} {this.LastName}";
    }
}