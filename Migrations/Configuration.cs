namespace TheThao247.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TheThao247.Models.TheThao247DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TheThao247.Models.TheThao247DBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            if (!context.Categories.Any())
            {
                var cat1 = new TheThao247.Models.Category { CategoryName = "Giày Bóng Đá" };
                var cat2 = new TheThao247.Models.Category { CategoryName = "Áo Đấu Thể Thao" };
                context.Categories.AddOrUpdate(cat1, cat2);
                context.SaveChanges();

                var p1 = new TheThao247.Models.Product { CategoryID = cat1.CategoryID, ProductName = "Giày Nike Mercurial Vapor 15", ProductDescription = "Giày sân cỏ nhân tạo", ProductPrice = 106548, ProductImage = "https://via.placeholder.com/150", Quantity = 50 };
                var p2 = new TheThao247.Models.Product { CategoryID = cat2.CategoryID, ProductName = "Áo Đấu Đội Tuyển", ProductDescription = "Thun lạnh co giãn", ProductPrice = 55900, ProductImage = "https://via.placeholder.com/150", Quantity = 100 };
                var p3 = new TheThao247.Models.Product { CategoryID = cat1.CategoryID, ProductName = "Găng Tay Thủ Môn Predator", ProductDescription = "Chống trơn trượt", ProductPrice = 142000, ProductImage = "https://via.placeholder.com/150", Quantity = 30 };
                context.Products.AddOrUpdate(p1, p2, p3);
                context.SaveChanges();

                var u1 = new TheThao247.Models.User { Username = "admin", Password = "123456", UserRole = "Admin" };
                var u2 = new TheThao247.Models.User { Username = "khach1", Password = "123456", UserRole = "Customer" };
                context.Users.AddOrUpdate(u1, u2);
                context.SaveChanges();

                var c1 = new TheThao247.Models.Customer { CustomerName = "Bui Thi Thanh Tu", CustomerPhone = "0901234567", CustomerEmail = "tubtt@huflit.edu.vn", CustomerAddress = "828 Sư Vạn Hạnh, Q10", Username = "khach1" };
                context.Customers.AddOrUpdate(c1);
                context.SaveChanges();

                var o1 = new TheThao247.Models.Order { CustomerID = c1.CustomerID, OrderDate = System.DateTime.Now, TotalAmount = 624092, PaymentMethod = "Tiền mặt", PaymentStatus = "Chưa thanh toán", DeliveryMethod = "Giao hàng nhanh", AddressDelivery = "828 Sư Vạn Hạnh, Q10" };
                var o2 = new TheThao247.Models.Order { CustomerID = c1.CustomerID, OrderDate = System.DateTime.Now, TotalAmount = 617000, PaymentMethod = "Tiền mặt", PaymentStatus = "Thanh toán tiền mặt", DeliveryMethod = "Giao hàng nhanh", AddressDelivery = "828 Sư Vạn Hạnh, Q10" };
                context.Orders.AddOrUpdate(o1, o2);
                context.SaveChanges();

                context.OrderDetails.AddOrUpdate(
                    new TheThao247.Models.OrderDetail { OrderID = o1.OrderID, ProductID = p1.ProductID, Quantity = 4, UnitPrice = 106548 },
                    new TheThao247.Models.OrderDetail { OrderID = o1.OrderID, ProductID = p2.ProductID, Quantity = 1, UnitPrice = 55900 },
                    new TheThao247.Models.OrderDetail { OrderID = o1.OrderID, ProductID = p3.ProductID, Quantity = 1, UnitPrice = 142000 }
                );
                context.SaveChanges();
            }
        }
    }
}
