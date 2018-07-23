using System.Collections.Generic;
using PurchaseControlSystem.Models.EntityModels;
using PurchaseControlSystem.Models.Enums;

namespace PurchaseControlSystem.Serveses.Contracts
{
    public interface IHomeServises
    {
        IEnumerable<PurchaseOrder> GetAllOrders(string status, string sortOrder);
        IEnumerable<PurchaseOrder> GetSortedEntities(IEnumerable<PurchaseOrder> orders,string sortOrder);
        void CreateOrder(PurchaseOrder purchaseOrder);
        IList<Customer> CustomersList();
        PurchaseOrder GetOrder(int id);
        void EditOrder(int id, string description, decimal price, int quantity, Status status, int customerId);
        void DeleteOrder(int id);
    }
}