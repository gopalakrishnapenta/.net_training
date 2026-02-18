using System;
public class Program
{
    public static void Main()
    {
        int a = 10;
        int b = 20;

        Swap<int>(ref a, ref b);
        Console.WriteLine($"a: {a}, b: {b}");

        string x = "Gopi";
        string  y = "Suresh";

        Swap<string>(ref x, ref y);
        Console.WriteLine($"x: {x}, y: {y}");
    }
        public static void Swap<T>(ref T x, ref T y)
    {
        T temp = x;
        x = y;
        y = temp;
    }


}