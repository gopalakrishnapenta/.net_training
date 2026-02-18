using System;
using System.Collections.Generic;
using System.Linq;

namespace FindItemsApp
{
    class Program
    {
        // SortedDictionary to store item name and sold count
        public static SortedDictionary<string, long> itemDetails =
            new SortedDictionary<string, long>()
            {
                { "Pen", 120 },
                { "Pencil", 80 },
                { "Notebook", 200 },
                { "Eraser", 50 }
            };

        static void Main(string[] args)
        {
            // Read sold count from user
            Console.WriteLine("Enter sold count to search:");
            long soldCount = Convert.ToInt64(Console.ReadLine());

            // Call FindItemDetails method
            var result = FindItemDetails(soldCount);

            // If result is empty, print invalid message
            if (result.Count == 0)
            {
                Console.WriteLine("Invalid sold count");
            }
            else
            {
                Console.WriteLine("Item Details:");
                foreach (var item in result)
                {
                    Console.WriteLine($"{item.Key} : {item.Value}");
                }
            }

            // Call Min and Max sold items method
            List<string> minMaxItems = FindMinandMaxSoldItems();
            Console.WriteLine("\nMinimum Sold Item: " + minMaxItems[0]);
            Console.WriteLine("Maximum Sold Item: " + minMaxItems[1]);

            // Call SortByCount method
            Console.WriteLine("\nItems sorted by sold count:");
            var sortedItems = SortByCount();
            foreach (var item in sortedItems)
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }
        }

        /// <summary>
        /// Finds item(s) matching the given sold count
        /// </summary>
        public static SortedDictionary<string, long> FindItemDetails(long soldCount)
        {
            SortedDictionary<string, long> result =
                new SortedDictionary<string, long>();

            // Iterate through itemDetails
            foreach (var item in itemDetails)
            {
                if (item.Value == soldCount)
                {
                    result.Add(item.Key, item.Value);
                }
            }

            return result;
        }

        /// <summary>
        /// Finds minimum and maximum sold items
        /// </summary>
        public static List<string> FindMinandMaxSoldItems()
        {
            List<string> result = new List<string>();

            // Find minimum sold value
            long minValue = itemDetails.Values.Min();

            // Find maximum sold value
            long maxValue = itemDetails.Values.Max();

            // Get item names
            string minItem = itemDetails.First(x => x.Value == minValue).Key;
            string maxItem = itemDetails.First(x => x.Value == maxValue).Key;

            // Add to list (min first, max second)
            result.Add(minItem);
            result.Add(maxItem);

            return result;
        }

        /// <summary>
        /// Sorts items based on sold count in ascending order
        /// </summary>
        public static Dictionary<string, long> SortByCount()
        {
            // Order by sold count and convert to Dictionary
            return itemDetails
                .OrderBy(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
