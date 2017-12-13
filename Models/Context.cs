using Microsoft.EntityFrameworkCore;

namespace ECommerceManager.Models
{
    public class Context : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Product> products {get;set;}
        public DbSet<Order> orders {get;set;}
        public DbSet<Customer> customers {get;set;}
    }
}