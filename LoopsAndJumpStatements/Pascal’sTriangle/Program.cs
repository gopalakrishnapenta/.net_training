using System;

class Program
{
    static void Main()
    {
        int n = 5;

        for (int i = 0; i < n; i++)
        {
            int number = 1;

            for (int space = 0; space < n - i; space++)
                Console.Write(" ");

            for (int j = 0; j <= i; j++)
            {
                Console.Write(number + " ");
                number = number * (i - j) / (j + 1);
            }

            Console.WriteLine();
        }
    }
}
