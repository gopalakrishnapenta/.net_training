using System;
using System.Collections.Generic;

namespace MovieTheaterSystem
{
    public class TheaterManager
    {
        private List<MovieScreening> screenings = new List<MovieScreening>();

        // Add new screening
        public void AddScreening(string title, DateTime time, string screen,
                                 int seats, double price)
        {
            MovieScreening screening = new MovieScreening();
            screening.MovieTitle = title;
            screening.ShowTime = time;
            screening.ScreenNumber = screen;
            screening.TotalSeats = seats;
            screening.BookedSeats = 0;
            screening.TicketPrice = price;

            screenings.Add(screening);
        }

        // Book tickets if seats are available
        public bool BookTickets(string movieTitle, DateTime showTime, int tickets)
        {
            foreach (MovieScreening screening in screenings)
            {
                if (screening.MovieTitle == movieTitle &&
                    screening.ShowTime == showTime)
                {
                    int availableSeats =
                        screening.TotalSeats - screening.BookedSeats;

                    if (availableSeats >= tickets)
                    {
                        screening.BookedSeats += tickets;
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }

        // Group screenings by movie title
        public Dictionary<string, List<MovieScreening>> GroupScreeningsByMovie()
        {
            // Create grouped dictionary
            Dictionary<string, List<MovieScreening>> result =
                new Dictionary<string, List<MovieScreening>>();
            // Populate grouped dictionary
            foreach (MovieScreening screening in screenings)
            {
                if (!result.ContainsKey(screening.MovieTitle))
                {
                    result[screening.MovieTitle] =
                        new List<MovieScreening>();
                }
                result[screening.MovieTitle].Add(screening);
            }

            return result;
        }

        // Calculate total revenue
        public double CalculateTotalRevenue()
        {
            double totalRevenue = 0;

            foreach (MovieScreening screening in screenings)
            {
                totalRevenue +=
                    screening.BookedSeats * screening.TicketPrice;
            }

            return totalRevenue;
        }

        // Get screenings with minimum available seats
        public List<MovieScreening> GetAvailableScreenings(int minSeats)
        {
            List<MovieScreening> available =
                new List<MovieScreening>();

            foreach (MovieScreening screening in screenings)
            {
                int availableSeats =
                    screening.TotalSeats - screening.BookedSeats;

                if (availableSeats >= minSeats)
                {
                    available.Add(screening);
                }
            }

            return available;
        }
    }
}
