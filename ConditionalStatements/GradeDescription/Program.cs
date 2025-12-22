using System;

class Program
{
    static void Main()
    {
        // Read grade input from user
        Console.Write("Enter grade (E, V, G, A, F): ");
        char grade = char.ToUpper(Console.ReadLine()[0]);

        // Display grade description
        if (grade == 'E')
            Console.WriteLine("Excellent");
        else if (grade == 'V')
            Console.WriteLine("Very Good");
        else if (grade == 'G')
            Console.WriteLine("Good");
        else if (grade == 'A')
            Console.WriteLine("Average");
        else if (grade == 'F')
            Console.WriteLine("Fail");
        else
            Console.WriteLine("Invalid Grade Entered");
    }
}
