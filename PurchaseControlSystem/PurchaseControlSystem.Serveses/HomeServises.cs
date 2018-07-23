using System;
using System.Collections.Generic;
using System.Linq;
using PurchaseControlSystem.Data.Contracts;
using PurchaseControlSystem.Models.EntityModels;
using PurchaseControlSystem.Models.Enums;
using PurchaseControlSystem.Serveses.Contracts;

namespace PurchaseControlSystem.Serveses
{
    public class HomeServises : Servises, IHomeServises
    {

        public HomeServises(IRepository<Customer> customerRepo, IRepository<PurchaseOrder> orderRepo) 
            : base(customerRepo, orderRepo)
        {
        }

        public IEnumerable<PurchaseOrder> GetAllOrders(string status, string sortOrder)
        {
            IEnumerable<PurchaseOrder> ordersEntities = new List<PurchaseOrder>();

            ordersEntities = Enum.TryParse(status, out Status targetStatus) ? this.OrderRepo.Find(ex => ex.Status == targetStatus) : this.OrderRepo.Find(ex => ex.Status != Status.Deleted);
            
            ordersEntities=GetSortedEntities(ordersEntities,sortOrder);
            
            return ordersEntities;

        }

        public IEnumerable<PurchaseOrder> GetSortedEntities(IEnumerable<PurchaseOrder> orders,string sortOrder)
        {
            switch (sortOrder)
            {
                case "desc":
                    orders = orders.OrderByDescending(o => o.Id);
                    break;
                case "SortDescription":
                    orders = orders.OrderBy(o => o.Description);
                    break;
                case "SortPrice":
                    orders = orders.OrderBy(o => o.Price);
                    break;
                case "SortQuantity":
                    orders = orders.OrderBy(o => o.Quantity);
                    break;
                default:
                    orders = orders.OrderBy(o => o.Id);
                    break;
            }

            return orders;
        }

        
        public void CreateOrder(PurchaseOrder order)
        {
            this.OrderRepo.Add(order);
            this.OrderRepo.Save();
        }

        public IList<Customer> CustomersList()
        {
            return this.CustomerRepo.GetAllList().ToList();
        }

        public PurchaseOrder GetOrder(int id)
        {
            PurchaseOrder order= this.OrderRepo.GetById(id);
            
            return order;
        }

        public void EditOrder(int id, string description, decimal price,int quantity,Status status,int customerId)
        {
            PurchaseOrder order = this.OrderRepo.GetById(id);
            order.Description = description;
            order.Price = price;
            order.Quantity = quantity;
            order.Status = status;
            order.CustomerId = customerId;
            this.OrderRepo.Save();

        }

        public void DeleteOrder(int id)
        {
            PurchaseOrder order = this.OrderRepo.GetById(id);
            order.Status = Status.Deleted;
            this.OrderRepo.Save();
        }


      
    }
}