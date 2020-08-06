using e_commerce_api.src.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_api.src.Contexts
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext(DbContextOptions<ECommerceContext> options) : base(options)
        {

        }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<CartModel>()
        //         .HasIndex(p => new { p.Customer, p.Product })
        //         .IsUnique(true);
        // }

        public DbSet<CartModel> Cart { get; set; }
        public DbSet<CustomerModel> Customer { get; set; }
        public DbSet<ProductModel> Product { get; set; }

    }
}