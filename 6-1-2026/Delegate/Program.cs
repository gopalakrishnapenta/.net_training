using System;
using Delegate;
namespace Delegate
{
public class Program
{
    public static void Main()
    {
        // Instantiate the delegate
        DelegateExample.MathOperation operation = new DelegateExample.MathOperation(DelegateExample.Add);
        // Instantiate another delegate for subtraction
        DelegateExample.MathOperation operation2 = new DelegateExample.MathOperation(DelegateExample.Subtract);

        // Invoke the delegate
        int Addresult = operation(5, 10);
        // Invoke the second delegate
        int SubResult = operation2(10, 5);
        Console.WriteLine("Result of Addition: " + Addresult);
        Console.WriteLine("Result of Subtraction: " + SubResult);
    }
}
}

