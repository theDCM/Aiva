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
        public DbSet<Promocode> Promocodes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=aiva;Username=postgres;Password=password");
        }
    }
}