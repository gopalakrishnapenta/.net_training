using System;

class Program
{
    static void Main()
    {
        // Read X and Y coordinates
        Console.Write("Enter X coordinate: ");
        int x = int.Parse(Console.ReadLine());

        Console.Write("Enter Y coordinate: ");
        int y = int.Parse(Console.ReadLine());

        // Determine the quadrant based on coordinate values
        if (x > 0 && y > 0)
            Console.WriteLine("Point lies in First Quadrant");
        else if (x < 0 && y > 0)
            Console.WriteLine("Point lies in Second Quadrant");
        else if (x < 0 && y < 0)
            Console.WriteLine("Point lies in Third Quadrant");
        else if (x > 0 && y < 0)
            Console.WriteLine("Point lies in Fourth Quadrant");
        else if (x == 0 && y == 0)
            Console.WriteLine("Point lies at Origin");
        else
            Console.WriteLine("Point lies on X or Y axis");
    }
}
