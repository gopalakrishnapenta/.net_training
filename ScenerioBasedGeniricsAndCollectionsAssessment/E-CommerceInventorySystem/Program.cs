using System;
using ECommerceInventorySystem.Models;
using ECommerceInventorySystem.Repository;
using ECommerceInventorySystem.Services;

namespace ECommerceInventorySystem
{
    class Program
    {
        static void Main()
        {
            var repository = new ProductRepository<ElectronicProduct>();
            var manager = new InventoryManager();

            // Add Products
            repository.AddProduct(new ElectronicProduct
            {
                Id = 1,
                Name = "Laptop",
                Price = 1200,
                Brand = "Dell",
                WarrantyMonths = 24
            });

            repository.AddProduct(new ElectronicProduct
            {
                Id = 2,
                Name = "Smartphone",
                Price = 850,
                Brand = "Samsung",
                WarrantyMonths = 12
            });

            repository.AddProduct(new ElectronicProduct
            {
                Id = 3,
                Name = "Headphones",
                Price = 150,
                Brand = "Sony",
                WarrantyMonths = 6
            });

            Console.WriteLine($"Total Inventory Value: {repository.CalculateTotalInventoryValue():C}");

            Console.WriteLine("\nFind by Brand (Samsung):");
            foreach (var product in repository.FindProducts(p => p.Brand == "Samsung"))
            {
                Console.WriteLine(product.Name);
            }

            manager.ProcessProducts(repository.GetAllProducts());

            Console.WriteLine("\n--- Updating Prices (+5%) ---");
            manager.UpdatePrices(
                repository.GetAllProducts(),
                p => p.Price * 1.05m
            );

            Console.WriteLine("\nUpdated Prices:");
            foreach (var product in repository.GetAllProducts())
            {
                Console.WriteLine($"{product.Name} - {product.Price:C}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
