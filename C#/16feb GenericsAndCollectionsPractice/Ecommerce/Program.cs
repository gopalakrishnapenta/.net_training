using System;
using System.Collections.Generic;
using System.Linq;

namespace Scenario1_ECommerce
{
    public interface IProduct
    {
        int Id { get; }
        string Name { get; }
        decimal Price { get; set; }
        Category Category { get; }
    }

    public enum Category { Electronics, Clothing, Books, Groceries }

    public class ProductRepository<T> where T : class, IProduct
    {
        private readonly List<T> _products = new();

        public void AddProduct(T product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (string.IsNullOrWhiteSpace(product.Name))
                throw new ArgumentException("Invalid Name");

            if (product.Price <= 0)
                throw new ArgumentException("Invalid Price");

            if (_products.Any(p => p.Id == product.Id))
                throw new InvalidOperationException("Duplicate ID");

            _products.Add(product);
        }

        public IEnumerable<T> FindProducts(Func<T, bool> predicate)
            => _products.Where(predicate);

        public decimal CalculateTotalValue()
            => _products.Sum(p => p.Price);

        public List<T> GetAll() => _products;
    }

    public class ElectronicProduct : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category => Category.Electronics;
        public int WarrantyMonths { get; set; }
        public string Brand { get; set; }
    }

    public class Program
    {
        public static void Main()
        {
            var repo = new ProductRepository<ElectronicProduct>();

            repo.AddProduct(new ElectronicProduct { Id = 1, Name = "Laptop", Price = 70000, Brand = "Dell", WarrantyMonths = 24 });
            repo.AddProduct(new ElectronicProduct { Id = 2, Name = "Mobile", Price = 30000, Brand = "Samsung", WarrantyMonths = 12 });
            repo.AddProduct(new ElectronicProduct { Id = 3, Name = "TV", Price = 55000, Brand = "Sony", WarrantyMonths = 36 });

            Console.WriteLine("Total Value: " + repo.CalculateTotalValue());

            var samsung = repo.FindProducts(p => p.Brand == "Samsung");
            Console.WriteLine("Samsung Products:");
            foreach (var p in samsung)
                Console.WriteLine(p.Name);
        }
    }
}
