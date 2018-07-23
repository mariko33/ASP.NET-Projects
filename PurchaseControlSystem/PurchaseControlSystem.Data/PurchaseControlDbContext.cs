using PurchaseControlSystem.Models.EntityModels;

namespace PurchaseControlSystem.Data
{
    using System.Data.Entity;

    public class PurchaseControlDbContext : DbContext
    {
       
        public PurchaseControlDbContext()
            : base("PurchaseControlDbContext")
        {
        }

        

        public virtual DbSet<Customer>Customers { get; set; }
        public virtual DbSet<PurchaseOrder>Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //One-to-Many RelationShip
            modelBuilder.Entity<PurchaseOrder>()
                .HasRequired<Customer>(p => p.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey<int>(c => c.CustomerId);
        }
    }

    

}