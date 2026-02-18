using System;

class Program
{
    static void Main()
    {
        // Read three sides of the triangle
        Console.Write("Enter side A: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Enter side B: ");
        int b = int.Parse(Console.ReadLine());

        Console.Write("Enter side C: ");
        int c = int.Parse(Console.ReadLine());

        // Check triangle type using conditional statements
        if (a == b && b == c)
        {
            // All sides are equal
            Console.WriteLine("Equilateral Triangle");
        }
        else if (a == b || b == c || a == c)
        {
            // Any two sides are equal
            Console.WriteLine("Isosceles Triangle");
        }
        else
        {
            // All sides are different
            Console.WriteLine("Scalene Triangle");
        }
    }
}
