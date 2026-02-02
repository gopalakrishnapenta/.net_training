using System;
using System.Collections.Generic;
using MovieTheaterSystem;

namespace MovieTheaterSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            TheaterManager manager = new TheaterManager();

            // Add screenings
            manager.AddScreening("Inception",
                new DateTime(2026, 2, 10, 18, 0, 0), "Screen 1", 100, 250);

            manager.AddScreening("Inception",
                new DateTime(2026, 2, 10, 21, 0, 0), "Screen 1", 100, 250);

            manager.AddScreening("Avatar",
                new DateTime(2026, 2, 10, 19, 0, 0), "Screen 2", 120, 300);

            // Book tickets
            manager.BookTickets("Inception",
                new DateTime(2026, 2, 10, 18, 0, 0), 5);

            manager.BookTickets("Avatar",
                new DateTime(2026, 2, 10, 19, 0, 0), 10);

            // Group screenings by movie
            Console.WriteLine("Screenings By Movie:");
            Dictionary<string, List<MovieScreening>> grouped =
                manager.GroupScreeningsByMovie();

            foreach (var movie in grouped)
            {
                Console.WriteLine("\nMovie: " + movie.Key);
                foreach (MovieScreening s in movie.Value)
                {
                    Console.WriteLine(
                        $"Time: {s.ShowTime}, Screen: {s.ScreenNumber}");
                }
            }

            // Available screenings
            Console.WriteLine("\nAvailable Screenings (min 50 seats):");
            List<MovieScreening> available =
                manager.GetAvailableScreenings(50);

            foreach (MovieScreening s in available)
            {
                Console.WriteLine(
                    $"{s.MovieTitle} - {s.ShowTime}");
            }

            // Total revenue
            Console.WriteLine("\nTotal Revenue: ₹" +
                manager.CalculateTotalRevenue());
        }
    }
}
