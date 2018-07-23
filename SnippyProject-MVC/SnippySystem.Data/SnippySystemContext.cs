using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using SnippySystem.Models.EntityModels;

namespace SnippySystem.Data
{
    public class SnippySystemContext : IdentityDbContext<ApplicationUser>
    {

        public SnippySystemContext()
            : base("SnippySystemContext")
        {
        }

        public static SnippySystemContext Create()
        {
            return new SnippySystemContext();
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Label> Labels { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Snippet> Snippets { get; set; }
        public virtual DbSet<UserLogged> UserLoggeds { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}