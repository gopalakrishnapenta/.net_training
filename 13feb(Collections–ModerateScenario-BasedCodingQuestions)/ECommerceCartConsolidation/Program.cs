using System;
using System.Collections.Generic;

namespace ECommerceCartConsolidation
{
    public class CartConsolidationService
    {
        public static Dictionary<string, int> ConsolidateSkuQuantities(
            List<(string Sku, int Quantity)> scanItems)
        {
            var skuQuantities = new Dictionary<string, int>();

            foreach (var scanItem in scanItems)
            {
                // Ignore invalid quantities
                if (scanItem.Quantity <= 0)
                    continue;

                if (skuQuantities.TryGetValue(scanItem.Sku, out int existingQuantity))
                {
                    skuQuantities[scanItem.Sku] = existingQuantity + scanItem.Quantity;
                }
                else
                {
                    skuQuantities[scanItem.Sku] = scanItem.Quantity;
                }
            }

            return skuQuantities;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var scanItems = new List<(string Sku, int Quantity)>
            {
                ("A101", 2),
                ("B205", 1),
                ("A101", 3),
                ("C111", -1)
            };

            var consolidatedResult =
                CartConsolidationService.ConsolidateSkuQuantities(scanItems);

            Console.WriteLine("Consolidated Cart:");

            foreach (var item in consolidatedResult)
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }
        }
    }
}
