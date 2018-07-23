using PurchaseControlSystem.Models.Enums;

namespace PurchaseControlSystem.Web.Models.ViewModels
{
    public class PurchaseOrderVm
    {
        public int Id { get; set; }
        
        public string Description { get; set; }
        
        public decimal Price { get; set; }
        
        public int Quantity { get; set; }
        
        public decimal TotalAmount => this.Price * this.Quantity;
      
        public Status Status { get; set; }

        
    }
}