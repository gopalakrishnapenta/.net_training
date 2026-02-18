using System;

class Program
{
    static void Main()
    {
        int number = 145;
        int temp = number;
        int sum = 0;

        while (temp > 0)
        {
            int digit = temp % 10;
            int fact = 1;

            for (int i = 1; i <= digit; i++)
                fact *= i;

            sum += fact;
            temp /= 10;
        }

        Console.WriteLine(sum == number ? "Strong Number" : "Not a Strong Number");
    }
}
