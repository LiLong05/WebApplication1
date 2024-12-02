using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class SanPhamDbcontext : DbContext
    {
        public SanPhamDbcontext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CartItem> Carts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> Items { get; set; }
    }
}
