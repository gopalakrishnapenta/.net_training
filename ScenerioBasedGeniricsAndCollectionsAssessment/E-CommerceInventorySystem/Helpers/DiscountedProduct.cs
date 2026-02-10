using System;
using ECommerceInventorySystem.Models;

namespace ECommerceInventorySystem.Helpers
{
    public class DiscountedProduct<T> where T : IProduct
    {
        private readonly T _product;
        private readonly decimal _discountPercentage;

        public DiscountedProduct(T product, decimal discountPercentage)
        {
            _product = product ?? throw new ArgumentNullException(nameof(product));

            if (discountPercentage < 0 || discountPercentage > 100)
                throw new ArgumentException("Discount must be between 0 and 100.");

            _discountPercentage = discountPercentage;
        }

        public decimal DiscountedPrice =>
            _product.Price * (1 - _discountPercentage / 100);

        public override string ToString()
        {
            return $"{_product.Name} | Original: {_product.Price:C} | " +
                   $"Discount: {_discountPercentage}% | Final: {DiscountedPrice:C}";
        }
    }
}
