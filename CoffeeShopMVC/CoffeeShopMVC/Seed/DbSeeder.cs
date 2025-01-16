using CoffeeShopMVC.Data;
using CoffeeShopMVC.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopMVC.Seed
{
    public static class DbSeeder
    {
        public static async Task SeedSampleDataAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            // Sprawdź, czy już nie ma kategorii
            if (!context.Categories.Any())
            {
                var cat1 = new Category { Name = "Kawa ziarnista" };
                var cat2 = new Category { Name = "Kawa mielona" };
                var cat3 = new Category { Name = "Akcesoria" };

                context.Categories.AddRange(cat1, cat2, cat3);
                await context.SaveChangesAsync();

                // Dodajmy proste produkty
                var p1 = new Product
                {
                    Name = "Espresso Beans",
                    Description = "Mocno palona kawa ziarnista",
                    Price = 25.50m,
                    StockQuantity = 100,
                    CategoryId = cat1.CategoryId
                };
                var p2 = new Product
                {
                    Name = "Arabica Mielona",
                    Description = "Delikatna kawa mielona 100% Arabica",
                    Price = 18.00m,
                    StockQuantity = 50,
                    CategoryId = cat2.CategoryId
                };
                var p3 = new Product
                {
                    Name = "Dripper Hario V60",
                    Description = "Akcesorium do przelewowego parzenia kawy",
                    Price = 45.00m,
                    StockQuantity = 10,
                    CategoryId = cat3.CategoryId
                };

                context.Products.AddRange(p1, p2, p3);
                await context.SaveChangesAsync();
            }
        }
    }
}