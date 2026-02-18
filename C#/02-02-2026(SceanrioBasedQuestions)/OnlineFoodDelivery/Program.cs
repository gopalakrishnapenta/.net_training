using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineFoodDelivery
{
    // Restaurant class
    class Restaurant
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string CuisineType { get; set; }
        public string Location { get; set; }
        public double DeliveryCharge { get; set; }
    }

    // FoodItem class
    class FoodItem
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int RestaurantId { get; set; }
    }

    // Order class
    class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public List<FoodItem> Items { get; set; }
        public DateTime OrderTime { get; set; }
        public string Status { get; set; }
        public double TotalAmount { get; set; }

        public Order()
        {
            Items = new List<FoodItem>();
        }
    }

    // DeliveryManager class
    class DeliveryManager
    {
        private List<Restaurant> restaurants = new List<Restaurant>();
        private List<FoodItem> foodItems = new List<FoodItem>();
        private List<Order> orders = new List<Order>();

        private int restaurantIdCounter = 1;
        private int itemIdCounter = 1;
        private int orderIdCounter = 1;

        // Add restaurant
        public void AddRestaurant(string name, string cuisine,
                                  string location, double charge)
        {
            Restaurant restaurant = new Restaurant
            {
                RestaurantId = restaurantIdCounter++,
                Name = name,
                CuisineType = cuisine,
                Location = location,
                DeliveryCharge = charge
            };

            restaurants.Add(restaurant);
            Console.WriteLine("Restaurant added successfully");
        }

        // Add food item
        public void AddFoodItem(int restaurantId, string name,
                                string category, double price)
        {
            FoodItem item = new FoodItem
            {
                ItemId = itemIdCounter++,
                Name = name,
                Category = category,
                Price = price,
                RestaurantId = restaurantId
            };

            foodItems.Add(item);
            Console.WriteLine("Food item added successfully");
        }

        // Group restaurants by cuisine
        public Dictionary<string, List<Restaurant>> GroupRestaurantsByCuisine()
        {
            return restaurants
                .GroupBy(r => r.CuisineType)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        // Place order
        public bool PlaceOrder(int customerId, List<int> itemIds)
        {
            List<FoodItem> orderedItems =
                foodItems.Where(f => itemIds.Contains(f.ItemId)).ToList();

            if (orderedItems.Count == 0)
                return false;

            double total = orderedItems.Sum(i => i.Price);

            Order order = new Order
            {
                OrderId = orderIdCounter++,
                CustomerId = customerId,
                Items = orderedItems,
                OrderTime = DateTime.Now,
                Status = "Pending",
                TotalAmount = total
            };

            orders.Add(order);
            return true;
        }

        // Get pending orders
        public List<Order> GetPendingOrders()
        {
            return orders
                .Where(o => o.Status == "Pending")
                .ToList();
        }
    }

    // Program class
    class Program
    {
        static void Main()
        {
            DeliveryManager manager = new DeliveryManager();

            // Add restaurants
            manager.AddRestaurant("Spice Hub", "Indian", "Hyderabad", 40);
            manager.AddRestaurant("Pizza Town", "Italian", "Bangalore", 50);

            // Add food items
            manager.AddFoodItem(1, "Chicken Biryani", "Main Course", 250);
            manager.AddFoodItem(1, "Paneer Curry", "Main Course", 200);
            manager.AddFoodItem(2, "Margherita Pizza", "Pizza", 300);

            // Place order
            bool status = manager.PlaceOrder(101, new List<int> { 1, 3 });
            Console.WriteLine("Order Placed: " + status);

            // Group restaurants by cuisine
            Console.WriteLine("\nRestaurants Grouped By Cuisine:");
            var grouped = manager.GroupRestaurantsByCuisine();
            foreach (var group in grouped)
            {
                Console.WriteLine(group.Key);
                foreach (var r in group.Value)
                    Console.WriteLine(r.Name);
            }

            // View pending orders
            Console.WriteLine("\nPending Orders:");
            var pending = manager.GetPendingOrders();
            foreach (var order in pending)
                Console.WriteLine("Order ID: " + order.OrderId +
                                  " Total: " + order.TotalAmount);
        }
    }
}
