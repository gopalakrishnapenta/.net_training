using System;
namespace Delegate
{
    

public class DelegateExample
{
    // Define a delegate that takes two integers and returns an integer
    public delegate int MathOperation(int a, int b);
    // Static methods for addition and subtraction
    public static int Add(int a, int b)
    {
        return a + b;
    }

    // Static method for subtraction
    public static int Subtract(int a, int b)
    {
        return a - b;
    }
}

}