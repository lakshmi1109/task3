// ECommerceApp/Data/DbInitializer.cs
using ECommerceApp.Models;

namespace ECommerceApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any products.
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            var products = new Product[]
            {
                new Product{Name="Laptop", Description="A high-end gaming laptop.", Price=1200.00M, ImageUrl="/images/laptop.png"},
                new Product{Name="Smartphone", Description="The latest smartphone model.", Price=800.00M, ImageUrl="/images/smartphone.png"},
                new Product{Name="Headphones", Description="Noise-cancelling headphones.", Price=150.00M, ImageUrl="/images/headphones.png"},
                new Product{Name="Keyboard", Description="Mechanical keyboard.", Price=100.00M, ImageUrl="/images/keyboard.png"},
            };

            foreach (Product p in products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();
        }
    }
}