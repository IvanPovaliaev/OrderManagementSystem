using Microsoft.EntityFrameworkCore;
using RepositoryService.Domain.Models;
using RepositoryService.Infrastructure.Persistence.Configurations;

namespace RepositoryService.Infrastructure.Persistence
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductConfigurations());
        }
    }
}
