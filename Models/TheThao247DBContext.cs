using System.Data.Entity;

namespace TheThao247.Models
{
    public class TheThao247DBContext : DbContext
    {
        // Tên chuỗi kết nối "TheThao247DBContext" sẽ khai báo trong Web.config ở Bước 3
        public TheThao247DBContext() : base("name=TheThao247DBContext")
        {
            Database.SetInitializer<TheThao247DBContext>(null);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}