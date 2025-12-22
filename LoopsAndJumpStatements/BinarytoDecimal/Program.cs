using System;

class Program
{
    static void Main()
    {
        string binary = "1011";
        int decimalValue = 0;
        int power = 1;

        // Traverse binary from right to left
        for (int i = binary.Length - 1; i >= 0; i--)
        {
            if (binary[i] == '1')
                decimalValue += power;

            power *= 2;
        }

        Console.WriteLine("Decimal Value = " + decimalValue);
    }
}
