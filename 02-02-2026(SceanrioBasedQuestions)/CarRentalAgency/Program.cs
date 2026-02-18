using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRentalAgency
{
    // RentalCar class
    class RentalCar
    {
        public string LicensePlate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string CarType { get; set; }   // Sedan / SUV / Van
        public bool IsAvailable { get; set; }
        public double DailyRate { get; set; }
    }

    // Rental class
    class Rental
    {
        public int RentalId { get; set; }
        public string LicensePlate { get; set; }
        public string CustomerName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double TotalCost { get; set; }
    }

    // RentalManager class
    class RentalManager
    {
        private List<RentalCar> cars = new List<RentalCar>();
        private List<Rental> rentals = new List<Rental>();
        private int rentalIdCounter = 1;

        // Add car to inventory
        public void AddCar(string license, string make, string model,
                           string type, double rate)
        {
            RentalCar car = new RentalCar
            {
                LicensePlate = license,
                Make = make,
                Model = model,
                CarType = type,
                DailyRate = rate,
                IsAvailable = true
            };

            cars.Add(car);
            Console.WriteLine("Car added successfully");
        }

        // Rent a car if available
        public bool RentCar(string license, string customer,
                            DateTime start, int days)
        {
            RentalCar car = cars.FirstOrDefault(c =>
                c.LicensePlate == license && c.IsAvailable);

            if (car == null)
                return false;

            DateTime endDate = start.AddDays(days);
            double cost = car.DailyRate * days;

            Rental rental = new Rental
            {
                RentalId = rentalIdCounter++,
                LicensePlate = license,
                CustomerName = customer,
                StartDate = start,
                EndDate = endDate,
                TotalCost = cost
            };

            rentals.Add(rental);
            car.IsAvailable = false;

            return true;
        }

        // Groups available cars by type
        public Dictionary<string, List<RentalCar>> GroupCarsByType()
        {
            return cars
                .Where(c => c.IsAvailable)
                .GroupBy(c => c.CarType)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        // Returns current rentals
        public List<Rental> GetActiveRentals()
        {
            DateTime today = DateTime.Now;

            return rentals
                .Where(r => r.StartDate <= today && r.EndDate >= today)
                .ToList();
        }

        // Sum of all rental costs
        public double CalculateTotalRentalRevenue()
        {
            return rentals.Sum(r => r.TotalCost);
        }
    }

    // Program class
    class Program
    {
        static void Main()
        {
            RentalManager manager = new RentalManager();

            // Add cars
            manager.AddCar("AP09AB1234", "Toyota", "Camry", "Sedan", 2500);
            manager.AddCar("TS10CD5678", "Mahindra", "XUV700", "SUV", 3500);
            manager.AddCar("KA05EF9999", "Tata", "Winger", "Van", 4000);

            // Rent a car
            bool rented = manager.RentCar(
                "AP09AB1234",
                "Ramesh",
                DateTime.Now,
                3);

            Console.WriteLine("Rental Status: " + rented);

            // Group available cars by type
            Console.WriteLine("\nAvailable Cars By Type:");
            var groupedCars = manager.GroupCarsByType();
            foreach (var group in groupedCars)
            {
                Console.WriteLine(group.Key);
                foreach (var car in group.Value)
                    Console.WriteLine(car.LicensePlate + " - " + car.Model);
            }

            // Active rentals
            Console.WriteLine("\nActive Rentals:");
            var activeRentals = manager.GetActiveRentals();
            foreach (var rental in activeRentals)
                Console.WriteLine(rental.CustomerName + " - " + rental.LicensePlate);

            // Total revenue
            Console.WriteLine("\nTotal Rental Revenue: " +
                manager.CalculateTotalRentalRevenue());
        }
    }
}
