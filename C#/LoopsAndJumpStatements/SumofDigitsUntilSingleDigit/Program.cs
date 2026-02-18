using System;

class Program
{
    static void Main()
    {
        int number = 9875;

        while (number >= 10)
        {
            int sum = 0;

            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }

            number = sum;
        }

        Console.WriteLine("Digital Root = " + number);
    }
}
