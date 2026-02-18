using System;
using System.Data;
using System.Linq.Expressions;
public class LeapYearChecker
{
    public static void Main(String[] args)
    {
        Console.Write("Enter a Year: ");
        String input = Console.ReadLine();
        if(int.TryParse(input,out int year))
        {
            if((year % 4 ==0 && year % 100! ==0) || (year %400 == 0))
            {
                Console.WriteLine(year +" is a leap year. ");
            }
            else
            {
                Console.WriteLine(year + " is not a leap year. ");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid year. ");
        }
    }
}