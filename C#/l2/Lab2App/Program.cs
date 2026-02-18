using System;

public class EvenOrOdd
{
    // Method to check even
    public bool IsEven(int number)
    {
        return number % 2 == 0;
    }

    public static void Main(string[] args)
    {
        EvenOrOdd checker = new EvenOrOdd();
        string? input = "";

        // Loop runs until user types "exit"
        while (input == null || input.ToLower() != "exit")
        {
            Console.Write("\nEnter a number (or type 'exit' to quit): ");
            input = Console.ReadLine();

            // If user typed exit, loop condition will stop next time
            if (input != null && input.ToLower() != "exit")
            {
                if (int.TryParse(input, out int number))
                {
                    if (checker.IsEven(number))
                        Console.WriteLine("The number is EVEN.");
                    else
                        Console.WriteLine("The number is ODD.");
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter a valid integer.");
                }
            }
        }

        Console.WriteLine("Program stopped.");
    }
}
