using System;
using System.Collections.Generic;

namespace MetroTicketingSystem
{
    public class TicketProcessor
    {
        private static readonly TimeSpan PeakStart = new TimeSpan(8, 0, 0);
        private static readonly TimeSpan PeakEnd = new TimeSpan(10, 0, 0);

        public static int CountPeakHourRegularTickets(
            Queue<(TimeSpan EntryTime, string TicketType)> passengerQueue)
        {
            if (passengerQueue == null)
                throw new ArgumentNullException(nameof(passengerQueue));

            int regularTicketCount = 0;

            while (passengerQueue.Count > 0)
            {
                var passenger = passengerQueue.Dequeue();

                if (string.IsNullOrWhiteSpace(passenger.TicketType))
                    continue;

                if (passenger.TicketType.Equals("Regular", StringComparison.OrdinalIgnoreCase)
                    && passenger.EntryTime >= PeakStart
                    && passenger.EntryTime <= PeakEnd)
                {
                    regularTicketCount++;
                }
            }

            return regularTicketCount;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var passengerQueue = new Queue<(TimeSpan EntryTime, string TicketType)>();

            passengerQueue.Enqueue((new TimeSpan(8, 15, 0), "Regular"));
            passengerQueue.Enqueue((new TimeSpan(9, 30, 0), "Premium"));
            passengerQueue.Enqueue((new TimeSpan(10, 0, 0), "Regular"));
            passengerQueue.Enqueue((new TimeSpan(7, 45, 0), "Regular"));
            passengerQueue.Enqueue((new TimeSpan(8, 45, 0), "Regular"));

            int peakRegularCount =
                TicketProcessor.CountPeakHourRegularTickets(passengerQueue);

            Console.WriteLine($"Peak Hour Regular Tickets Sold: {peakRegularCount}");
        }
    }
}
