using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryStockManagement
{
    // Product class
    class Product
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string Supplier { get; set; }
        public double UnitPrice { get; set; }
        public int CurrentStock { get; set; }
        public int MinimumStockLevel { get; set; }
    }

    // StockMovement class
    class StockMovement
    {
        public int MovementId { get; set; }
        public string ProductCode { get; set; }
        public DateTime MovementDate { get; set; }
        public string MovementType { get; set; } // In / Out
        public int Quantity { get; set; }
        public string Reason { get; set; } // Purchase / Sale / Return
    }

    // InventoryManager class
    class InventoryManager
    {
        private List<Product> products = new List<Product>();
        private List<StockMovement> movements = new List<StockMovement>();
        private int movementCounter = 1;

        // Add product
        public void AddProduct(string code, string name, string category,
                               string supplier, double price,
                               int stock, int minLevel)
        {
            Product product = new Product
            {
                ProductCode = code,
                ProductName = name,
                Category = category,
                Supplier = supplier,
                UnitPrice = price,
                CurrentStock = stock,
                MinimumStockLevel = minLevel
            };

            products.Add(product);
            Console.WriteLine("Product added successfully");
        }

        // Update stock (In / Out)
        public bool UpdateStock(string productCode, string movementType,
                                int quantity, string reason)
        {
            Product product = products
                .FirstOrDefault(p => p.ProductCode == productCode);

            if (product == null || quantity <= 0)
                return false;

            if (movementType == "Out" && product.CurrentStock < quantity)
                return false;

            if (movementType == "In")
                product.CurrentStock += quantity;
            else if (movementType == "Out")
                product.CurrentStock -= quantity;
            else
                return false;

            movements.Add(new StockMovement
            {
                MovementId = movementCounter++,
                ProductCode = productCode,
                MovementDate = DateTime.Now,
                MovementType = movementType,
                Quantity = quantity,
                Reason = reason
            });

            return true;
        }

        // Group products by category
        public Dictionary<string, List<Product>> GroupProductsByCategory()
        {
            return products
                .GroupBy(p => p.Category)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        // Get low stock products
        public List<Product> GetLowStockProducts()
        {
            return products
                .Where(p => p.CurrentStock <= p.MinimumStockLevel)
                .ToList();
        }

        // Get stock value by category
        public Dictionary<string, int> GetStockValueByCategory()
        {
            return products
                .GroupBy(p => p.Category)
                .ToDictionary(
                    g => g.Key,
                    g => g.Sum(p => p.CurrentStock)
                );
        }
    }

    // Program class
    class Program
    {
        static void Main()
        {
            InventoryManager manager = new InventoryManager();

            // Add products
            manager.AddProduct("P101", "Laptop", "Electronics",
                               "Dell", 55000, 10, 3);

            manager.AddProduct("P102", "Mouse", "Electronics",
                               "Logitech", 800, 50, 10);

            manager.AddProduct("P201", "Chair", "Furniture",
                               "IKEA", 3000, 5, 2);

            // Update stock
            manager.UpdateStock("P101", "Out", 8, "Sale");
            manager.UpdateStock("P102", "Out", 45, "Sale");

            // Group products by category
            Console.WriteLine("\nProducts Grouped By Category:");
            var grouped = manager.GroupProductsByCategory();
            foreach (var group in grouped)
            {
                Console.WriteLine(group.Key);
                foreach (var p in group.Value)
                    Console.WriteLine(p.ProductName);
            }

            // Low stock products
            Console.WriteLine("\nLow Stock Products:");
            var lowStock = manager.GetLowStockProducts();
            foreach (var p in lowStock)
                Console.WriteLine(p.ProductName +
                                  " Stock: " + p.CurrentStock);

            // Stock value by category
            Console.WriteLine("\nStock Value By Category:");
            var stockValue = manager.GetStockValueByCategory();
            foreach (var item in stockValue)
                Console.WriteLine(item.Key + " : " + item.Value);
        }
    }
}
