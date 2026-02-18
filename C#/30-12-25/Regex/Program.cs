using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string input = "Error: TIMEOUT while calling API";
        string pattern = @"timeout";

        var rx = new Regex(
            pattern,
            RegexOptions.IgnoreCase,
            TimeSpan.FromMilliseconds(1) // match timeout
        );

        Console.WriteLine(rx.IsMatch(input) ? "Found" : "Not Found");
    }
}