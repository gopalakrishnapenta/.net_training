using System;
using System.Collections.Generic;

namespace AttendanceProcessing
{
    public class AttendanceService
    {
        public static List<int> GetFirstUniqueEntries(List<int> scanRecords)
        {
            var seenEmployeeIds = new HashSet<int>();
            var firstTimeEntries = new List<int>();

            foreach (var employeeId in scanRecords)
            {
                if (!seenEmployeeIds.Contains(employeeId))
                {
                    seenEmployeeIds.Add(employeeId);
                    firstTimeEntries.Add(employeeId);
                }
            }

            return firstTimeEntries;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var scanRecords = new List<int> { 10, 20, 10, 30, 20, 40 };

            var firstTimeEntries =
                AttendanceService.GetFirstUniqueEntries(scanRecords);

            Console.WriteLine("First-Time Attendance Entries:");

            foreach (var employeeId in firstTimeEntries)
            {
                Console.WriteLine(employeeId);
            }
        }
    }
}
