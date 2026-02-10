using System;
using System.Collections.Generic;
using System.Linq;
using ECommerceInventorySystem.Models;
using ECommerceInventorySystem.Helpers;

namespace ECommerceInventorySystem.Services
{
    public class InventoryManager
    {
        public void ProcessProducts<T>(IEnumerable<T> products) where T : IProduct
        {
            if (products == null || !products.Any())
            {
                Console.WriteLine("No products available.");
                return;
            }

            Console.WriteLine("\n--- Product List ---");
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Name} - {product.Price:C}");
            }

            var mostExpensive = products.OrderByDescending(p => p.Price).First();
            Console.WriteLine($"\nMost Expensive: {mostExpensive.Name} ({mostExpensive.Price:C})");

            Console.WriteLine("\n--- Grouped by Category ---");
            foreach (var group in products.GroupBy(p => p.Category))
            {
                Console.WriteLine(group.Key);
                foreach (var item in group)
                {
                    Console.WriteLine($"  - {item.Name}");
                }
            }

            Console.WriteLine("\n--- 10% Discount on Electronics > $500 ---");
            foreach (var product in products
                .Where(p => p.Category == Category.Electronics && p.Price > 500))
            {
                var discounted = new DiscountedProduct<IProduct>(product, 10);
                Console.WriteLine(discounted);
            }
        }

        public void UpdatePrices<T>(
            List<T> products,
            Func<T, decimal> priceUpdater) where T : IProduct
        {
            foreach (var product in products)
            {
                try
                {
                    decimal newPrice = priceUpdater(product);

                    if (newPrice <= 0)
                        throw new InvalidOperationException("Price must be positive.");

                    product.Price = newPrice;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to update {product.Name}: {ex.Message}");
                }
            }
        }
    }
}
