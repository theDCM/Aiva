using Aiva.Models;
using Microsoft.EntityFrameworkCore;

namespace Aiva.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Cook> Cooks { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Kitchen> Kitchen { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public DatabaseContext()
        {
            Database.EnsureCreated();
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
        {
            Database.Migrate();
        }
    }
}