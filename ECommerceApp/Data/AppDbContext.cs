using ECommerceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ECommerceAppDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CartItem> CartItems { get; set; }


    }
}
