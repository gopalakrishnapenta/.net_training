using System;
public class ArmstrongNumber
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Enter a number: ");
        String number = Console.ReadLine();
        if(int.TryParse(number, out int num))
        {
            int originalNum = num;
            int sum = 0;
            int digits = num.ToString().Length;

            while (num > 0)
            {
                int digit = num % 10;
                sum += (int)Math.Pow(digit, digits);
                num /= 10;
            }

            if (sum == originalNum)
            {
                Console.WriteLine(originalNum + " is an Armstrong number.");
            }
            else
            {
                Console.WriteLine(originalNum + " is not an Armstrong number.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }
}