using System;
using System.Collections.Generic;
using System.Linq;

namespace FlightBookingSystem
{
    // Flight class
    class Flight
    {
        public string FlightNumber { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public double TicketPrice { get; set; }
    }

    // Booking class
    class Booking
    {
        public string BookingId { get; set; }
        public string FlightNumber { get; set; }
        public string PassengerName { get; set; }
        public int SeatsBooked { get; set; }
        public double TotalFare { get; set; }
        public string SeatClass { get; set; } // Economy / Business
    }

    // AirlineManager class
    class AirlineManager
    {
        private List<Flight> flights = new List<Flight>();
        private List<Booking> bookings = new List<Booking>();
        private int bookingCounter = 1;

        // Add flight
        public void AddFlight(string number, string origin, string destination,
                              DateTime depart, DateTime arrive,
                              int seats, double price)
        {
            Flight flight = new Flight
            {
                FlightNumber = number,
                Origin = origin,
                Destination = destination,
                DepartureTime = depart,
                ArrivalTime = arrive,
                TotalSeats = seats,
                AvailableSeats = seats,
                TicketPrice = price
            };

            flights.Add(flight);
            Console.WriteLine("Flight added successfully");
        }

        // Book flight
        public bool BookFlight(string flightNumber, string passenger,
                               int seats, string seatClass)
        {
            Flight flight = flights.FirstOrDefault(f =>
                f.FlightNumber == flightNumber);

            if (flight == null || flight.AvailableSeats < seats)
                return false;

            double multiplier = seatClass == "Business" ? 1.5 : 1.0;
            double totalFare = seats * flight.TicketPrice * multiplier;

            Booking booking = new Booking
            {
                BookingId = "B" + bookingCounter++,
                FlightNumber = flightNumber,
                PassengerName = passenger,
                SeatsBooked = seats,
                SeatClass = seatClass,
                TotalFare = totalFare
            };

            bookings.Add(booking);
            flight.AvailableSeats -= seats;

            return true;
        }

        // Group flights by destination
        public Dictionary<string, List<Flight>> GroupFlightsByDestination()
        {
            return flights
                .GroupBy(f => f.Destination)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        // Search flights by route and date
        public List<Flight> SearchFlights(string origin, string destination,
                                          DateTime date)
        {
            return flights
                .Where(f => f.Origin == origin &&
                            f.Destination == destination &&
                            f.DepartureTime.Date == date.Date)
                .ToList();
        }

        // Calculate total revenue for a flight
        public double CalculateTotalRevenue(string flightNumber)
        {
            return bookings
                .Where(b => b.FlightNumber == flightNumber)
                .Sum(b => b.TotalFare);
        }
    }

    // Program class
    class Program
    {
        static void Main()
        {
            AirlineManager manager = new AirlineManager();

            // Add flights
            manager.AddFlight("AI101", "Delhi", "Mumbai",
                              DateTime.Now.AddHours(3),
                              DateTime.Now.AddHours(5),
                              100, 5000);

            manager.AddFlight("AI202", "Delhi", "Bangalore",
                              DateTime.Now.AddDays(1),
                              DateTime.Now.AddDays(1).AddHours(2),
                              120, 6000);

            // Book flight
            bool booked = manager.BookFlight("AI101", "Ravi", 2, "Economy");
            Console.WriteLine("Booking Status: " + booked);

            // Search flights
            Console.WriteLine("\nSearch Results:");
            var search = manager.SearchFlights("Delhi", "Mumbai", DateTime.Now);
            foreach (var f in search)
                Console.WriteLine(f.FlightNumber + " Seats Left: " + f.AvailableSeats);

            // Group flights by destination
            Console.WriteLine("\nFlights Grouped By Destination:");
            var grouped = manager.GroupFlightsByDestination();
            foreach (var group in grouped)
            {
                Console.WriteLine(group.Key);
                foreach (var f in group.Value)
                    Console.WriteLine(f.FlightNumber);
            }

            // Calculate revenue
            Console.WriteLine("\nTotal Revenue for AI101: " +
                              manager.CalculateTotalRevenue("AI101"));
        }
    }
}
