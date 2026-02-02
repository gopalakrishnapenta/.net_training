using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceCatalog
{
    public class InventoryManager
    {
        private List<Product> products;
        private int productCounter;

        public InventoryManager()
        {
            products = new List<Product>();
            productCounter = 0;
        }

        // Auto-generates product code and adds a product
        public void AddProduct(string name, string category, double price, int stock)
        {
            productCounter++;
            string code = $"P{productCounter:D3}"; // P001, P002, ...
            products.Add(new Product(code, name, category, price, stock));
        }

        // Groups products by category (sorted dictionary)
        public SortedDictionary<string, List<Product>> GroupProductsByCategory()
        {
            var grouped = products
                .GroupBy(p => p.Category)
                .ToDictionary(g => g.Key, g => g.ToList());

            return new SortedDictionary<string, List<Product>>(grouped);
        }

        // Updates stock, returns false if insufficient stock
        public bool UpdateStock(string productCode, int quantity)
        {
            var product = products.FirstOrDefault(p => p.ProductCode == productCode);
            if (product == null) return false;
            if (quantity > product.StockQuantity) return false;

            product.StockQuantity -= quantity;
            return true;
        }

        // Returns products below a certain price
        public List<Product> GetProductsBelowPrice(double maxPrice)
        {
            return products.Where(p => p.Price <= maxPrice).ToList();
        }

        // Returns total stock quantity per category
        public Dictionary<string, int> GetCategoryStockSummary()
        {
            return products
                .GroupBy(p => p.Category)
                .ToDictionary(g => g.Key, g => g.Sum(p => p.StockQuantity));
        }
    }
}
