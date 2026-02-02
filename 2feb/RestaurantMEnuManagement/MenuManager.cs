using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantMenu
{
    public class MenuManager
    {
        private List<MenuItem> menuItems;

        public MenuManager()
        {
            menuItems = new List<MenuItem>();
        }

        // Adds a menu item with price validation
        public void AddMenuItem(string name, string category, double price, bool isVeg)
        {
            if (price <= 0)
            {
                Console.WriteLine("Price must be greater than 0. Item not added.");
                return;
            }

            menuItems.Add(new MenuItem(name, category, price, isVeg));
        }

        // Groups menu items by category
        public Dictionary<string, List<MenuItem>> GroupItemsByCategory()
        {
            return menuItems
                .GroupBy(item => item.Category)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        // Returns all vegetarian items
        public List<MenuItem> GetVegetarianItems()
        {
            return menuItems.Where(item => item.IsVegetarian).ToList();
        }

        // Calculates average price for a given category
        public double CalculateAveragePriceByCategory(string category)
        {
            var itemsInCategory = menuItems.Where(item => item.Category == category).ToList();
            if (itemsInCategory.Count == 0)
                return 0;

            return itemsInCategory.Average(item => item.Price);
        }
    }
}
