using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        int n = 50;
        BigInteger factorial = 1;

        for (int i = 1; i <= n; i++)
            factorial *= i;

        Console.WriteLine("Factorial = " + factorial);
    }
}
