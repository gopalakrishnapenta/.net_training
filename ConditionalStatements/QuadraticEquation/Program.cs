using System;
public class QuadraticEquation
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Enter coefficients a, b and c of the quadratic equation (ax^2 + bx + c = 0):");
        
        Console.Write("a: ");
        String inputA = Console.ReadLine();
        Console.Write("b: ");
        String inputB = Console.ReadLine();
        Console.Write("c: ");
        String inputC = Console.ReadLine();

        if (double.TryParse(inputA, out double a) && double.TryParse(inputB, out double b) && double.TryParse(inputC, out double c))
        {
            if (a == 0)
            {
                Console.WriteLine("Coefficient 'a' cannot be zero in a quadratic equation.");
                return;
            }

            double discriminant = b * b - 4 * a * c;

            if (discriminant > 0)
            {
                double root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                double root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                Console.WriteLine($"Two distinct real roots: {root1} and {root2}");
            }
            else if (discriminant == 0)
            {
                double root = -b / (2 * a);
                Console.WriteLine($"One real root: {root}");
            }
            else
            {
                Console.WriteLine("No real roots exist.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter valid numbers for coefficients a, b, and c.");
        }
    }
}