using System;

class Program
{
    static void Main()
    {
        int secret = 7;
        int guess;

        do
        {
            Console.Write("Guess the number: ");
            guess = int.Parse(Console.ReadLine());

        } while (guess != secret);

        Console.WriteLine("Correct Guess!");
    }
}
