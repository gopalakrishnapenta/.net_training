using System;
using RestaurantMenu; // Import the namespace for MenuItem and MenuManager

namespace RestaurantMenuApp
{
    class Program
    {
        static void Main()
        {
            MenuManager menuManager = new MenuManager();

            // 1. Add menu items
            menuManager.AddMenuItem("Bruschetta", "Appetizer", 5.5, true);
            menuManager.AddMenuItem("Caesar Salad", "Appetizer", 6.0, false);
            menuManager.AddMenuItem("Grilled Salmon", "Main Course", 15.0, false);
            menuManager.AddMenuItem("Veggie Burger", "Main Course", 12.0, true);
            menuManager.AddMenuItem("Chocolate Cake", "Dessert", 6.5, true);
            menuManager.AddMenuItem("Ice Cream", "Dessert", 4.0, true);

            // 2. Display menu categorized by course
            var groupedMenu = menuManager.GroupItemsByCategory();
            Console.WriteLine("Menu by Category:");
            foreach (var category in groupedMenu)
            {
                Console.WriteLine($"\n{category.Key}:");
                foreach (var item in category.Value)
                {
                    Console.WriteLine($"- {item}");
                }
            }

            // 3. Show vegetarian-only menu
            var vegItems = menuManager.GetVegetarianItems();
            Console.WriteLine("\nVegetarian Menu:");
            foreach (var item in vegItems)
            {
                Console.WriteLine($"- {item}");
            }

            // 4. Calculate average prices per category
            Console.WriteLine("\nAverage Prices:");
            foreach (var category in new[] { "Appetizer", "Main Course", "Dessert" })
            {
                double avgPrice = menuManager.CalculateAveragePriceByCategory(category);
                Console.WriteLine($"{category}: ${avgPrice:F2}");
            }

            // Keep console open
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
