using System;
using System.Collections.Generic;

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
            Dictionary<string, List<Product>> grouped = new Dictionary<string, List<Product>>();
            
            foreach (var product in products)
            {
                if (!grouped.ContainsKey(product.Category))
                {
                    grouped[product.Category] = new List<Product>();
                }
                grouped[product.Category].Add(product);
            }

            return new SortedDictionary<string, List<Product>>(grouped);
        }

        // Updates stock, returns false if insufficient stock
        public bool UpdateStock(string productCode, int quantity)
        {
            Product product = null;
            foreach (var p in products)
            {
                if (p.ProductCode == productCode)
                {
                    product = p;
                    break;
                }
            }
            
            if (product == null) return false;
            if (quantity > product.StockQuantity) return false;

            product.StockQuantity -= quantity;
            return true;
        }

        // Returns products below a certain price
        public List<Product> GetProductsBelowPrice(double maxPrice)
        {
            List<Product> result = new List<Product>();
            foreach (var product in products)
            {
                if (product.Price <= maxPrice)
                {
                    result.Add(product);
                }
            }
            return result;
        }

        // Returns total stock quantity per category
        public Dictionary<string, int> GetCategoryStockSummary()
        {
            Dictionary<string, int> summary = new Dictionary<string, int>();
            
            foreach (var product in products)
            {
                if (!summary.ContainsKey(product.Category))
                {
                    summary[product.Category] = 0;
                }
                summary[product.Category] += product.StockQuantity;
            }
            
            return summary;
        }
    }
}
