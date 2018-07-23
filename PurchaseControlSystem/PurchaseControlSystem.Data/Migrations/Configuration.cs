using PurchaseControlSystem.Models.EntityModels;
using PurchaseControlSystem.Models.Enums;

namespace PurchaseControlSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<PurchaseControlSystem.Data.PurchaseControlDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PurchaseControlSystem.Data.PurchaseControlDbContext context)
        {

            context.Customers.AddOrUpdate(
                c=>c.FirstName,
                new Customer()
                {
                    FirstName = "Ivan",
                    LastName = "Petrov",
                    Telephone = "0888554411",
                    Sex = Sex.Male,
                    Status = Status.Active
                    
                },


                new Customer()
                {
                    FirstName = "Petar",
                    LastName = "Popov",
                    Telephone = "0888554422",
                    Sex = Sex.Male,
                    Status = Status.Active

                },
                new Customer()
                {
                    FirstName = "Lili",
                    LastName = "Petrova",
                    Telephone = "0888554433",
                    Sex = Sex.Female,
                    Status = Status.Active

                },
                new Customer()
                {
                    FirstName = "Viki",
                    LastName = "Ivanova",
                    Telephone = "0888554444",
                    Sex = Sex.Female,
                    Status = Status.Inactive

                }



                );
        }

    }
}
