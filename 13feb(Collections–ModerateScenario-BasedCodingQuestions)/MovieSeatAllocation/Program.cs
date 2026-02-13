using System;
using System.Collections.Generic;

namespace MovieSeatAllocation
{
    public class SeatAllocationService
    {
        public static List<int> AllocateSeats(
            int totalSeats,
            List<int> alreadyBookedSeats,
            int requestCount)
        {
            if (totalSeats <= 0)
                throw new ArgumentException("Total seats must be greater than zero.");

            var availableSeats = new SortedSet<int>();

            // Add all seats initially
            for (int seatNumber = 1; seatNumber <= totalSeats; seatNumber++)
            {
                availableSeats.Add(seatNumber);
            }

            // Remove already booked seats
            foreach (var bookedSeat in alreadyBookedSeats)
            {
                availableSeats.Remove(bookedSeat);
            }

            var allocatedSeats = new List<int>();

            for (int i = 0; i < requestCount; i++)
            {
                if (availableSeats.Count > 0)
                {
                    int lowestSeat = availableSeats.Min;
                    allocatedSeats.Add(lowestSeat);
                    availableSeats.Remove(lowestSeat);
                }
                else
                {
                    allocatedSeats.Add(-1);
                }
            }

            return allocatedSeats;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int totalSeats = 5;
            var alreadyBookedSeats = new List<int> { 2, 4 };
            int requestCount = 5;

            var allocatedSeats =
                SeatAllocationService.AllocateSeats(
                    totalSeats,
                    alreadyBookedSeats,
                    requestCount);

            Console.WriteLine("Allocated Seats:");

            foreach (var seat in allocatedSeats)
            {
                Console.WriteLine(seat);
            }
        }
    }
}
