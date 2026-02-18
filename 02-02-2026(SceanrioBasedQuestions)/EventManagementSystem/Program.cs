using System;
using System.Collections.Generic;
using System.Linq;

namespace EventManagementSystem
{
    // Event class
    class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string EventType { get; set; } // Concert / Conference / Workshop
        public DateTime EventDate { get; set; }
        public string Venue { get; set; }
        public int TotalCapacity { get; set; }
        public int TicketsSold { get; set; }
        public double TicketPrice { get; set; }
    }

    // Attendee class
    class Attendee
    {
        public int AttendeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<int> RegisteredEvents { get; set; }

        public Attendee()
        {
            RegisteredEvents = new List<int>();
        }
    }

    // Ticket class
    class Ticket
    {
        public string TicketNumber { get; set; }
        public int EventId { get; set; }
        public int AttendeeId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string SeatNumber { get; set; }
    }

    // EventManager class
    class EventManager
    {
        private List<Event> events = new List<Event>();
        private List<Attendee> attendees = new List<Attendee>();
        private List<Ticket> tickets = new List<Ticket>();

        private int eventCounter = 1;
        private int attendeeCounter = 1;
        private int ticketCounter = 1;

        // Create event
        public void CreateEvent(string name, string type, DateTime date,
                                string venue, int capacity, double price)
        {
            Event ev = new Event
            {
                EventId = eventCounter++,
                EventName = name,
                EventType = type,
                EventDate = date,
                Venue = venue,
                TotalCapacity = capacity,
                TicketsSold = 0,
                TicketPrice = price
            };

            events.Add(ev);
            Console.WriteLine("Event created successfully");
        }

        // Register attendee (helper)
        public int AddAttendee(string name, string email, string phone)
        {
            Attendee at = new Attendee
            {
                AttendeeId = attendeeCounter++,
                Name = name,
                Email = email,
                Phone = phone
            };

            attendees.Add(at);
            return at.AttendeeId;
        }

        // Book ticket
        public bool BookTicket(int eventId, int attendeeId, string seatNumber)
        {
            Event ev = events.FirstOrDefault(e => e.EventId == eventId);
            Attendee at = attendees.FirstOrDefault(a => a.AttendeeId == attendeeId);

            if (ev == null || at == null)
                return false;

            if (ev.TicketsSold >= ev.TotalCapacity)
                return false;

            Ticket ticket = new Ticket
            {
                TicketNumber = "T" + ticketCounter++,
                EventId = eventId,
                AttendeeId = attendeeId,
                PurchaseDate = DateTime.Now,
                SeatNumber = seatNumber
            };

            tickets.Add(ticket);
            ev.TicketsSold++;
            at.RegisteredEvents.Add(eventId);

            return true;
        }

        // Group events by type
        public Dictionary<string, List<Event>> GroupEventsByType()
        {
            return events
                .GroupBy(e => e.EventType)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        // Get upcoming events
        public List<Event> GetUpcomingEvents(int days)
        {
            DateTime today = DateTime.Today;
            DateTime limit = today.AddDays(days);

            return events
                .Where(e => e.EventDate >= today && e.EventDate <= limit)
                .ToList();
        }

        // Calculate event revenue
        public double CalculateEventRevenue(int eventId)
        {
            Event ev = events.FirstOrDefault(e => e.EventId == eventId);
            if (ev == null)
                return 0;

            return ev.TicketsSold * ev.TicketPrice;
        }
    }

    // Program class
    class Program
    {
        static void Main()
        {
            EventManager manager = new EventManager();

            // Create events
            manager.CreateEvent("Rock Concert", "Concert",
                                DateTime.Now.AddDays(5),
                                "City Arena", 3, 1500);

            manager.CreateEvent("Tech Conference", "Conference",
                                DateTime.Now.AddDays(10),
                                "Convention Hall", 100, 3000);

            // Add attendees
            int a1 = manager.AddAttendee("Ravi", "ravi@mail.com", "9999999999");
            int a2 = manager.AddAttendee("Anita", "anita@mail.com", "8888888888");

            // Book tickets
            manager.BookTicket(1, a1, "A1");
            manager.BookTicket(1, a2, "A2");

            // Group events by type
            Console.WriteLine("\nEvents Grouped By Type:");
            var grouped = manager.GroupEventsByType();
            foreach (var g in grouped)
            {
                Console.WriteLine(g.Key);
                foreach (var e in g.Value)
                    Console.WriteLine(e.EventName);
            }

            // Upcoming events
            Console.WriteLine("\nUpcoming Events (Next 7 Days):");
            var upcoming = manager.GetUpcomingEvents(7);
            foreach (var e in upcoming)
                Console.WriteLine(e.EventName + " on " + e.EventDate.ToShortDateString());

            // Event revenue
            Console.WriteLine("\nRevenue for Event 1: " +
                              manager.CalculateEventRevenue(1));
        }
    }
}
