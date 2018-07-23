using System;
using System.Collections.Generic;
using System.Linq;
using PurchaseControlSystem.Data;
using PurchaseControlSystem.Data.Contracts;
using PurchaseControlSystem.Data.Repositories;
using PurchaseControlSystem.Models.EntityModels;
using PurchaseControlSystem.Models.Enums;

namespace RandomDataGenerator
{
    class Program
    {
        static void Main()
        {
            PurchaseControlDbContext context = new PurchaseControlDbContext();

            IRepository<Customer> customersRepo = new CustomerRepository(context);
            IRepository<PurchaseOrder> ordersRepo = new PurchaseOrderRepository(context);
           

            IEnumerable<int> customersIdList = customersRepo.GetAllList().Select(c => c.Id);

            int customerIdFirst = customersIdList.First();
            int customerIdLast = customersIdList.Last();

            Random rnd = new Random();

            for (int i = 0; i < 1000; i++)
            {
                PurchaseOrder order = new PurchaseOrder()
                {
                    Description = GenearteRandomSting(rnd.Next(3, 50)),
                    Price = new decimal(rnd.NextDouble()),
                    Quantity = rnd.Next(1, 100),
                    Status = (Status)rnd.Next(1, 4),
                    CustomerId = rnd.Next(customerIdFirst, customerIdLast)
                };

               
                ordersRepo.Add(order);
                ordersRepo.Save();
               
            }

           

        }

        public static string GenearteRandomSting(int length)
        {
            //generate sting only from small letters

            char[] charArr = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            Random rnd = new Random();
            string randomStr = String.Empty;
            for (int i = 0; i < length; i++)
            {
                int x = rnd.Next(1, charArr.Length);
                randomStr += charArr.GetValue(x);

            }

            return randomStr;
        }
    }
}
