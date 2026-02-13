using System;
using System.Collections.Generic;

namespace CustomerSupportTicketMerge
{
    public class TicketMergeService
    {
        public static List<int> MergeSortedTickets(
            List<int> firstTicketStream,
            List<int> secondTicketStream)
        {
            if (firstTicketStream == null)
                throw new ArgumentNullException(nameof(firstTicketStream));

            if (secondTicketStream == null)
                throw new ArgumentNullException(nameof(secondTicketStream));

            var mergedTickets = new List<int>(
                firstTicketStream.Count + secondTicketStream.Count);

            int indexA = 0;
            int indexB = 0;

            while (indexA < firstTicketStream.Count &&
                   indexB < secondTicketStream.Count)
            {
                if (firstTicketStream[indexA] <= secondTicketStream[indexB])
                {
                    mergedTickets.Add(firstTicketStream[indexA]);
                    indexA++;
                }
                else
                {
                    mergedTickets.Add(secondTicketStream[indexB]);
                    indexB++;
                }
            }

            // Add remaining elements from first list
            while (indexA < firstTicketStream.Count)
            {
                mergedTickets.Add(firstTicketStream[indexA]);
                indexA++;
            }

            // Add remaining elements from second list
            while (indexB < secondTicketStream.Count)
            {
                mergedTickets.Add(secondTicketStream[indexB]);
                indexB++;
            }

            return mergedTickets;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var firstTicketStream = new List<int> { 1, 4, 7 };
            var secondTicketStream = new List<int> { 2, 3, 8 };

            var mergedTickets =
                TicketMergeService.MergeSortedTickets(
                    firstTicketStream,
                    secondTicketStream);

            Console.WriteLine("Merged Ticket Stream:");

            foreach (var ticketId in mergedTickets)
            {
                Console.WriteLine(ticketId);
            }
        }
    }
}
