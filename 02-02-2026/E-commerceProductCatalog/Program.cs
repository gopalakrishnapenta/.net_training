using System;
using ECommerceCatalog;
using System.Collections.Generic;

namespace ECommerceApp
{
    class Program
    {
        static void Main()
        {
            InventoryManager inventory = new InventoryManager();

            // 1. Add products
            inventory.AddProduct("Laptop", "Electronics", 1200.0, 10);
            inventory.AddProduct("Smartphone", "Electronics", 800.0, 15);
            inventory.AddProduct("Jeans", "Clothing", 50.0, 25);
            inventory.AddProduct("T-Shirt", "Clothing", 20.0, 50);
            inventory.AddProduct("C# Programming Book", "Books", 40.0, 30);
            inventory.AddProduct("Novel", "Books", 15.0, 40);

            // 2. Display products grouped by category
            var groupedProducts = inventory.GroupProductsByCategory();
            Console.WriteLine("Products by Category:");
            foreach (var category in groupedProducts)
            {
                Console.WriteLine($"\n{category.Key}:");
                foreach (var product in category.Value)
                {
                    Console.WriteLine($"- {product}");
                }
            }

            // 3. Update stock after a sale
            Console.WriteLine("\nUpdating stock...");
            bool sold = inventory.UpdateStock("P001", 3); // Sell 3 laptops
            Console.WriteLine(sold ? "Stock updated." : "Insufficient stock!");

            // 4. Find products under a certain price
            Console.WriteLine("\nProducts under $50:");
            var cheapProducts = inventory.GetProductsBelowPrice(50);
            foreach (var product in cheapProducts)
            {
                Console.WriteLine($"- {product}");
            }

            // 5. Show inventory summary
            Console.WriteLine("\nInventory Summary (Total stock per category):");
            var summary = inventory.GetCategoryStockSummary();
            foreach (var kvp in summary)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} items");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
