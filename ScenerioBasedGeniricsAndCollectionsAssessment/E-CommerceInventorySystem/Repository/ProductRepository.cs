using System;
using System.Collections.Generic;
using System.Linq;
using ECommerceInventorySystem.Models;

namespace ECommerceInventorySystem.Repository
{
    public class ProductRepository<T> where T : class, IProduct
    {
        private readonly List<T> _products = new();

        public void AddProduct(T product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (_products.Any(p => p.Id == product.Id))
                throw new ArgumentException("Product ID must be unique.");

            if (string.IsNullOrWhiteSpace(product.Name))
                throw new ArgumentException("Product name cannot be empty.");

            if (product.Price <= 0)
                throw new ArgumentException("Price must be positive.");

            _products.Add(product);
        }

        public IEnumerable<T> FindProducts(Func<T, bool> predicate)
        {
            return _products.Where(predicate);
        }

        public decimal CalculateTotalInventoryValue()
        {
            return _products.Sum(p => p.Price);
        }

        public List<T> GetAllProducts()
        {
            return _products;
        }
    }
}
