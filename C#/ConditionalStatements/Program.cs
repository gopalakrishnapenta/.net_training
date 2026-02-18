using System;
class lab1
{
    static void Main()
    {
        Console.Write("radius: ");
        string input = Console.ReadLine();

        if (double.TryParse(input, out double radius))
        {
            double area = Math.PI * radius * radius;
            Console.WriteLine("Area: " + area);
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a numeric value for the radius.");
        }
    }
}