using System;

class Program
{
    static void Main()
    {
        // Read day, month, and year
        Console.Write("Enter Day: ");
        int day = int.Parse(Console.ReadLine());

        Console.Write("Enter Month: ");
        int month = int.Parse(Console.ReadLine());

        Console.Write("Enter Year: ");
        int year = int.Parse(Console.ReadLine());

        // Check if the year is a leap year
        bool isLeapYear = (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);

        int maxDays;

        // Determine maximum days in the given month
        if (month == 2)
            maxDays = isLeapYear ? 29 : 28;
        else if (month == 4 || month == 6 || month == 9 || month == 11)
            maxDays = 30;
        else if (month >= 1 && month <= 12)
            maxDays = 31;
        else
        {
            Console.WriteLine("Invalid Date");
            return;
        }

        // Validate the day
        if (day >= 1 && day <= maxDays)
            Console.WriteLine("Valid Date");
        else
            Console.WriteLine("Invalid Date");
    }
}
