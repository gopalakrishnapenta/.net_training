using System;
using System.Collections.Generic;
using System.Linq;

namespace RealEstatePropertyManagement
{
    // Property class
    class Property
    {
        public string PropertyId { get; set; }
        public string Address { get; set; }
        public string PropertyType { get; set; } // Apartment / House / Villa
        public int Bedrooms { get; set; }
        public double AreaSqFt { get; set; }
        public double Price { get; set; }
        public string Status { get; set; } // Available / Sold / Rented
        public string Owner { get; set; }
    }

    // Client class
    class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string ClientType { get; set; } // Buyer / Renter
        public double Budget { get; set; }
        public List<string> Requirements { get; set; }

        public Client()
        {
            Requirements = new List<string>();
        }
    }

    // Viewing class
    class Viewing
    {
        public int ViewingId { get; set; }
        public string PropertyId { get; set; }
        public int ClientId { get; set; }
        public DateTime ViewingDate { get; set; }
        public string Feedback { get; set; }
    }

    // RealEstateManager class
    class RealEstateManager
    {
        private List<Property> properties = new List<Property>();
        private List<Client> clients = new List<Client>();
        private List<Viewing> viewings = new List<Viewing>();

        private int clientCounter = 1;
        private int viewingCounter = 1;
        private int propertyCounter = 101;

        // Add property
        public void AddProperty(string address, string type, int bedrooms,
                                double area, double price, string owner)
        {
            Property property = new Property
            {
                PropertyId = "P" + propertyCounter++,
                Address = address,
                PropertyType = type,
                Bedrooms = bedrooms,
                AreaSqFt = area,
                Price = price,
                Status = "Available",
                Owner = owner
            };

            properties.Add(property);
            Console.WriteLine("Property added successfully");
        }

        // Add client
        public void AddClient(string name, string contact, string type,
                              double budget, List<string> requirements)
        {
            Client client = new Client
            {
                ClientId = clientCounter++,
                Name = name,
                Contact = contact,
                ClientType = type,
                Budget = budget,
                Requirements = requirements
            };

            clients.Add(client);
            Console.WriteLine("Client added successfully");
        }

        // Schedule viewing
        public bool ScheduleViewing(string propertyId, int clientId, DateTime date)
        {
            Property property = properties
                .FirstOrDefault(p => p.PropertyId == propertyId && p.Status == "Available");

            Client client = clients.FirstOrDefault(c => c.ClientId == clientId);

            if (property == null || client == null)
                return false;

            Viewing viewing = new Viewing
            {
                ViewingId = viewingCounter++,
                PropertyId = propertyId,
                ClientId = clientId,
                ViewingDate = date,
                Feedback = "Pending"
            };

            viewings.Add(viewing);
            return true;
        }

        // Group properties by type
        public Dictionary<string, List<Property>> GroupPropertiesByType()
        {
            return properties
                .GroupBy(p => p.PropertyType)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        // Get properties within budget
        public List<Property> GetPropertiesInBudget(double minPrice, double maxPrice)
        {
            return properties
                .Where(p => p.Price >= minPrice && p.Price <= maxPrice)
                .ToList();
        }
    }

    // Program class
    class Program
    {
        static void Main()
        {
            RealEstateManager manager = new RealEstateManager();

            // Add properties
            manager.AddProperty("Banjara Hills, Hyderabad", "Apartment",
                                3, 1800, 9500000, "Ramesh");

            manager.AddProperty("Whitefield, Bangalore", "Villa",
                                4, 3200, 18000000, "Suresh");

            manager.AddProperty("Kukatpally, Hyderabad", "House",
                                2, 1400, 6500000, "Anita");

            // Add clients
            manager.AddClient("Ravi", "9999999999", "Buyer",
                              10000000, new List<string> { "Apartment", "3BHK" });

            manager.AddClient("Kiran", "8888888888", "Buyer",
                              7000000, new List<string> { "House", "2BHK" });

            // Schedule viewing
            bool scheduled = manager.ScheduleViewing("P101", 1, DateTime.Now.AddDays(2));
            Console.WriteLine("Viewing Scheduled: " + scheduled);

            // Group properties by type
            Console.WriteLine("\nProperties Grouped By Type:");
            var grouped = manager.GroupPropertiesByType();
            foreach (var group in grouped)
            {
                Console.WriteLine(group.Key);
                foreach (var p in group.Value)
                    Console.WriteLine(p.PropertyId + " - " + p.Address);
            }

            // Properties within budget
            Console.WriteLine("\nProperties Within Budget (6M - 10M):");
            var budgetProps = manager.GetPropertiesInBudget(6000000, 10000000);
            foreach (var p in budgetProps)
                Console.WriteLine(p.PropertyId + " - " + p.Price);
        }
    }
}
