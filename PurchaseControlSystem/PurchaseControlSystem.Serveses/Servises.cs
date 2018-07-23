using PurchaseControlSystem.Data.Contracts;
using PurchaseControlSystem.Models.EntityModels;
using PurchaseControlSystem.Serveses.Contracts;

namespace PurchaseControlSystem.Serveses
{
    public abstract class Servises : IServises
    {
        
        private IRepository<Customer> customerRepo;
        private IRepository<PurchaseOrder> orderRepo;

        public Servises(IRepository<Customer> customerRepo,IRepository<PurchaseOrder> orderRepo)
        {
           
            this.customerRepo = customerRepo;
            this.orderRepo = orderRepo;

        }

        public IRepository<Customer> CustomerRepo => this.customerRepo;

        public IRepository<PurchaseOrder> OrderRepo => this.orderRepo;
    }
}