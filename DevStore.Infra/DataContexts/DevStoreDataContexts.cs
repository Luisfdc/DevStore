using DevStore.Domain;
using System.Data.Entity;

namespace DevStore.Infra.DataContexts
{
    public class DevStoreDataContexts : DbContext
    {
        public DevStoreDataContexts()
            :base("DevStoreConnectionString")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }

        public DbSet<Message> Message { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
