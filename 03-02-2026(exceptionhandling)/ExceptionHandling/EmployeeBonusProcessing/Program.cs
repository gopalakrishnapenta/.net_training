using System;
using System.Net;
class BonusCalculator
{
    public static void Main()
    {
        int[] salaries = {5000, 0 , 7000, 6000};
        int bonus = 10000;

        for (int i=0;i<salaries.Length;i++)
{
            try
            {
                int result = bonus/salaries[i];
                Console.WriteLine($"Employee{i+1}: Bonus share = {result}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine($"Employee{i+1}: Salary cannot be zero.");
            }
        }  
        Console.WriteLine("Bonus distribution completed.");  
    }
}