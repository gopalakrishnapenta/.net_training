using System;

class InputHandler
{
    static void Main()
    {
        int number = 0;           // ✅ Initialize variable
        bool isValid = false;

        while (!isValid)
        {
            Console.WriteLine("Enter a valid number:");

            string? input = Console.ReadLine();   // ✅ Nullable string

            if (input == null)
            {
                Console.WriteLine("Input cannot be null.");
                continue;
            }

            isValid = int.TryParse(input, out number);

            if (!isValid)
            {
                Console.WriteLine("Invalid input. Please enter numbers only.");
            }
        }

        Console.WriteLine("You entered: " + number);
    }
}
