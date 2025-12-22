using System;

class Program
{
    static void Main()
    {
        // Read first number
        Console.Write("Enter first number: ");
        double num1 = double.Parse(Console.ReadLine());

        // Read operator
        Console.Write("Enter operator (+, -, *, /): ");
        char op = Console.ReadLine()[0];

        // Read second number
        Console.Write("Enter second number: ");
        double num2 = double.Parse(Console.ReadLine());

        // Perform calculation based on operator
        if (op == '+')
            Console.WriteLine("Result = " + (num1 + num2));
        else if (op == '-')
            Console.WriteLine("Result = " + (num1 - num2));
        else if (op == '*')
            Console.WriteLine("Result = " + (num1 * num2));
        else if (op == '/')
            Console.WriteLine("Result = " + (num1 / num2));
        else
            Console.WriteLine("Invalid Operator");
    }
}
