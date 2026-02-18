using System;
using ConstructorAdd;
namespace ConstructorAdd
{
   public class Program
    {
        public static void Main(String [] args)
        {
            ConstructorAddEx add1 = new ConstructorAddEx(5, 10);
            Console.WriteLine($"Values are A: {add1.A}, B: {add1.B}, Sum: {add1.Sum}");
        }
    }
}