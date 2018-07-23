using System;
using System.Linq;
using PurchaseControlSystem.Models.EntityModels;
using PurchaseControlSystem.Models.Enums;

namespace PurchaseControlSystem.Data.Repositories
{
    public class CustomerRepository : Repository<Customer>
    {
        public CustomerRepository(PurchaseControlDbContext context) : base(context)
        {
        }

        public override void Delete(Customer entity)
        {
            Customer targetCustomer = this.Context.Customers.FirstOrDefault(c => c.Id == entity.Id);
            if (targetCustomer == null)
            {
                throw new NullReferenceException("There is no such customer");
            }
            targetCustomer.Status = (Status)Enum.Parse(typeof(Status), "Deleted");
        }
    }
}