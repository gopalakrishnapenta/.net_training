using System;

class Program
{
    static void Main()
    {
        int n = 5;

        // Upper half
        for (int i = 1; i <= n; i++)
        {
            for (int space = 1; space <= n - i; space++)
                Console.Write(" ");

            for (int star = 1; star <= 2 * i - 1; star++)
                Console.Write("*");

            Console.WriteLine();
        }

        // Lower half
        for (int i = n - 1; i >= 1; i--)
        {
            for (int space = 1; space <= n - i; space++)
                Console.Write(" ");

            for (int star = 1; star <= 2 * i - 1; star++)
                Console.Write("*");

            Console.WriteLine();
        }
    }
}
