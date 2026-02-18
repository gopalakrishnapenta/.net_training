using System;

class Program
{
    static void Main()
    {
        for (int i = 1; i <= 50; i++)
        {
            if (i % 3 == 0)
                continue;

            Console.Write(i + " ");
        }
    }
}
