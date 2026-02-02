using System;
using System.Collections.Generic;

namespace RestaurantMenu
{
    public class MenuManager
    {
        // List to store menu items
        private List<MenuItem> menuItems;

        // Constructor to initialize the menu items list
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
            Dictionary<string, List<MenuItem>> grouped = new Dictionary<string, List<MenuItem>>();
            
            foreach (var item in menuItems)
            {
                if (!grouped.ContainsKey(item.Category))
                {
                    grouped[item.Category] = new List<MenuItem>();
                }
                grouped[item.Category].Add(item);
            }
            
            return grouped;
        }

        // Returns all vegetarian items
        public List<MenuItem> GetVegetarianItems()
        {
            List<MenuItem> result = new List<MenuItem>();
            foreach (var item in menuItems)
            {
                if (item.IsVegetarian)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        // Calculates average price for a given category
        public double CalculateAveragePriceByCategory(string category)
        {
            List<MenuItem> itemsInCategory = new List<MenuItem>();
            foreach (var item in menuItems)
            {
                if (item.Category == category)
                {
                    itemsInCategory.Add(item);
                }
            }
            
            if (itemsInCategory.Count == 0)
                return 0;

            double totalPrice = 0;
            foreach (var item in itemsInCategory)
            {
                totalPrice += item.Price;
            }
            
            return totalPrice / itemsInCategory.Count;
        }
    }
}
