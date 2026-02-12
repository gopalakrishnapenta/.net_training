using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace String_Input_to_Number_Conversion
{
    public class ConversionFunctions
    {
        public void ToInt()
        {
            Console.WriteLine("Enter a number: ");
            string? input = Console.ReadLine();
            Convert.ToInt32(input);
            Console.WriteLine("Conversion to Int");
        }
        public void ToDouble()
        {
            Console.WriteLine("Enter a number: ");
            string? input = Console.ReadLine();
            Convert.ToDouble(input);
            Console.WriteLine("Conversion to Double");
        }
        public void SplitToInt()
        {
            string? input = Console.ReadLine();
            int[] splitted = input.Split(' ').Select(int.Parse).ToArray();
            Console.WriteLine("Enter numbers separated by space: ");
            foreach(var i in splitted)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Splitted and converted to int");
        }
        public void SplitToDouble()
        {
            Console.WriteLine("Enter numbers separated by space: ");
            string? input = Console.ReadLine()  ;
            double[] splitted = input.Split(' ').Select(double.Parse).ToArray();
            foreach(var i in splitted)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Splitted and converted to double.");
        }
        public void ValidateString()
        {
            Console.WriteLine("Enter a number: ");
            string? input = Console.ReadLine();
            try
            {
                int result = int.Parse(input);
                Console.WriteLine("Input is an Integer.");

            }
            catch
            {
                Console.WriteLine($"{input} is not an Integer.");
            }
        }
        
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            ConversionFunctions conversion = new ConversionFunctions();
            //conversion.ToInt();
            //conversion.ToDouble();
            //conversion.SplitToInt();
            //conversion.SplitToDouble();
            conversion.ValidateString();
        }
    }
}
