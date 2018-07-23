using System;
using System.Linq;
using PurchaseControlSystem.Models.EntityModels;
using PurchaseControlSystem.Models.Enums;

namespace PurchaseControlSystem.Data.Repositories
{
    public class PurchaseOrderRepository:Repository<PurchaseOrder>
    {
        public PurchaseOrderRepository(PurchaseControlDbContext context) : base(context)
        {
        }

        public override void Delete(PurchaseOrder entity)
        {
            PurchaseOrder targetEntity = this.Context.Orders.FirstOrDefault(c => c.Id == entity.Id);
            if (targetEntity == null)
            {
                throw new NullReferenceException("There is no such order");
            }
            targetEntity.Status = (Status)Enum.Parse(typeof(Status), "Deleted");
        }
    }
}