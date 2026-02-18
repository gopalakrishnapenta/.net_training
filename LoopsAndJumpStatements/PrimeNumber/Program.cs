using System;
public class PrimeNumber
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Enter a number: ");
        String number = Console.ReadLine();
        if(int.TryParse(number, out int num))
        {
            if (num <= 1)
            {
                Console.WriteLine(num + " is not a prime number.");
                return;
            }

            bool isPrime = true;
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime)
            {
                Console.WriteLine(num + " is a prime number.");
            }
            else
            {
                Console.WriteLine(num + " is not a prime number.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }
}