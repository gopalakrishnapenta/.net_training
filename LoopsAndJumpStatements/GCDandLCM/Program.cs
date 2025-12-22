using System;

class Program
{
    static void Main()
    {
        int a = 24, b = 36;
        int gcd = 1;

        // Loop from 1 to minimum of a and b
        for (int i = 1; i <= a && i <= b; i++)
        {
            if (a % i == 0 && b % i == 0)
                gcd = i;
        }

        // LCM formula using GCD
        int lcm = (a * b) / gcd;

        Console.WriteLine("GCD = " + gcd);
        Console.WriteLine("LCM = " + lcm);
    }
}
