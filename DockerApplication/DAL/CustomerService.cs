using Microsoft.EntityFrameworkCore;
using DockerApplication.Model;

namespace DockerApplication.DAL
{
    public class CustomerService : DbContext
    {
        public CustomerService(DbContextOptions<CustomerService> options) : base(options)
        {

        }
        public DbSet<CustomerEntity> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerEntity>()
                .ToTable(nameof(CustomerEntity));
        }
    }
}
