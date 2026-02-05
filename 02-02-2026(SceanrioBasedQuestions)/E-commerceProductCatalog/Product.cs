using System;

namespace ECommerceCatalog
{
    public class Product
    {
        public string ProductCode { get; private set; }
        public string ProductName { get; set; }
        public string Category { get; set; } // Electronics / Clothing / Books
        public double Price { get; set; }
        public int StockQuantity { get; set; }

        public Product(string productCode, string productName, string category, double price, int stockQuantity)
        {
            ProductCode = productCode;
            ProductName = productName;
            Category = category;
            Price = price;
            StockQuantity = stockQuantity;
        }

        public override string ToString()
        {
            return $"{ProductCode} - {ProductName} - {Category} - ${Price:F2} - Stock: {StockQuantity}";
        }
    }
}
