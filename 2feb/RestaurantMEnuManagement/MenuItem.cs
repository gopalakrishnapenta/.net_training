using System;

namespace RestaurantMenu
{
    public class MenuItem
    {
        public string ItemName { get; set; }
        public string Category { get; set; } // Appetizer / Main Course / Dessert
        public double Price { get; set; }
        public bool IsVegetarian { get; set; }

        public MenuItem(string itemName, string category, double price, bool isVegetarian)
        {
            ItemName = itemName;
            Category = category;
            Price = price;
            IsVegetarian = isVegetarian;
        }

        public override string ToString()
        {
            return $"{ItemName} - ${Price:F2} {(IsVegetarian ? "(Veg)" : "")}";
        }
    }
}
