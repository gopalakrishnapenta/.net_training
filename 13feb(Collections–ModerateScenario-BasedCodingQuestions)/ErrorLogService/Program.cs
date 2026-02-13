using System;
using System.Collections.Generic;

namespace LogAnalyzer
{
    public class ErrorLogService
    {
        public static string GetMostFrequentErrorCode(List<string> errorCodes)
        {
            if (errorCodes == null || errorCodes.Count == 0)
                throw new ArgumentException("Error code list cannot be empty.");

            var frequencyMap = new Dictionary<string, int>();

            foreach (var code in errorCodes)
            {
                if (frequencyMap.ContainsKey(code))
                {
                    frequencyMap[code]++;
                }
                else
                {
                    frequencyMap[code] = 1;
                }
            }

            string resultCode = null;
            int maxFrequency = 0;

            foreach (var entry in frequencyMap)
            {
                string currentCode = entry.Key;
                int currentFrequency = entry.Value;

                if (currentFrequency > maxFrequency)
                {
                    maxFrequency = currentFrequency;
                    resultCode = currentCode;
                }
                else if (currentFrequency == maxFrequency &&
                         string.Compare(currentCode, resultCode, StringComparison.Ordinal) < 0)
                {
                    resultCode = currentCode;
                }
            }

            return resultCode;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var errorCodes = new List<string>
            {
                "E02", "E01", "E02", "E01", "E03"
            };

            string result =
                ErrorLogService.GetMostFrequentErrorCode(errorCodes);

            Console.WriteLine($"Most Frequent Error Code: {result}");
        }
    }
}
