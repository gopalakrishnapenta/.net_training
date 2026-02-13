using System;
using System.Collections.Generic;

namespace InventoryDuplicateDetection
{
    public class InventoryService
    {
        public static List<string> DetectDuplicateSerials(List<string> serialNumbers)
        {
            if (serialNumbers == null)
                throw new ArgumentNullException(nameof(serialNumbers));

            var seenSerials = new HashSet<string>();
            var duplicateTracker = new HashSet<string>();
            var detectedDuplicates = new List<string>();

            foreach (var serial in serialNumbers)
            {
                if (!seenSerials.Add(serial)) // Already seen
                {
                    if (duplicateTracker.Add(serial)) // First time detected as duplicate
                    {
                        detectedDuplicates.Add(serial);
                    }
                }
            }

            return detectedDuplicates;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var serialNumbers = new List<string>
            {
                "S1", "S2", "S1", "S3", "S2", "S2"
            };

            var duplicates =
                InventoryService.DetectDuplicateSerials(serialNumbers);

            Console.WriteLine("Detected Duplicate Serials:");

            foreach (var serial in duplicates)
            {
                Console.WriteLine(serial);
            }
        }
    }
}
