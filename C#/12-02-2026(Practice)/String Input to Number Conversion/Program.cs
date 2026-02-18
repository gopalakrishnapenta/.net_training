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
        
    
        public void IntOutOfString()
        {
            Console.WriteLine("Enter a string containing a number: ");
            string? input = Console.ReadLine();
            double result = double.Parse(new string(input.TakeWhile(c => char.IsDigit(c) || c == '.').ToArray()));
            Console.WriteLine(result);
            Console.WriteLine("Extracting numeric value from string is successfull");

        }
        public void LongConversion()
        {
            Console.WriteLine("Enter a number: ");
            string? input = Console.ReadLine();
            if(long.TryParse(input, out long result))
            {
                Console.WriteLine(result);
                Console.WriteLine("Long Conversion is successfull");
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
       }
        public void HexToInt()
        {
            Console.WriteLine("Enter a hexadecimal number (starting with 0x): ");
            string? input = Console.ReadLine();
            int result = Convert.ToInt32(input.Substring(2), 16);
            Console.WriteLine(result);

        }
        public void ScienceToDouble()
        {
            string? input = Console.ReadLine();
            double result = double.Parse(input, System.Globalization.CultureInfo.InvariantCulture);
            Console.WriteLine(result);
            Console.WriteLine("Converting Science numerics to double is done.");
        }
        public void HandlingNumbers()
        {
            string? input = Console.ReadLine();
            double[] result = input.Split(' ').Select(double.Parse).ToArray();
            foreach(var i in result)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Handling positive and negative numbers is done.");
        }
        public void TrimFunction()
        {
            string? input = Console.ReadLine();
            int result = int.Parse(input.Trim());
            Console.WriteLine(result);
            Console.WriteLine("Triming the spaces has been done.");
        }
        public void DetectNumber()
        {
            string? input = Console.ReadLine();
            if (double.TryParse(input, out double result))
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Invalid Number");
            }
            Console.WriteLine("Checking whether the number is valid or not is done.");
        }
        public void FormatHandling()
        {
            string? input = Console.ReadLine();
            string? result = input.Replace('.', ' ');
            int number = int.Parse(result);
            Console.WriteLine(number);
            Console.WriteLine("Format Handling is done.");
        }
        public void FormatConversion()
        {
            string? input = Console.ReadLine();
            double result = double.Parse(input, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture);
            Console.WriteLine(result);
            Console.WriteLine("Format Conversion is done.");
        }
        public void TreatingNegative()
        {
            string? input = Console.ReadLine();
            int result = -int.Parse(input.Trim('(', ')'));
            Console.WriteLine(result);
            Console.WriteLine("Treating a Number as Negative is done.");
        }
        public void ConvertHoursIntoMinutes()
        {
            var input = Console.ReadLine().Split(':');
            int minutes = int.Parse(input[0]) * 60 + int.Parse(input[1]);
            Console.WriteLine(minutes);
            Console.WriteLine("Converting Hours into Minutes is done.");
        }
        public void ExtractAndConvertNumeric()
        {
            string? input=Console.ReadLine();
            string Value = input.Replace('$', ' ').Replace(',', ' ');
            double result = double.Parse(Value);
            Console.WriteLine(result);
            Console.WriteLine("Extracted and Converted the numeric portion.");
        }
        public void IntSumFromString()
        {
            string? input = Console.ReadLine();
            int result = input.Split(' ').Where(x=>int.TryParse(x, out _)).Select(int.Parse).Sum();
            Console.WriteLine(result);
            Console.WriteLine("Extracting integers from a string and printing the sum is done.");
        }
        public void BinaryToInt()
        {
            string? input= Console.ReadLine();
            int result = Convert.ToInt32(input, 2);
            Console.WriteLine(result);
            Console.WriteLine("Binary to Integer Conversion is done.");
        }
        public void ExtractAndSum()
        {
            string? input = Console.ReadLine();
            var numbers = System.Text.RegularExpressions.Regex.Matches(input, @"[\d,]+").Select(m => int.Parse(m.Value.Replace(',', ' ')));
            Console.WriteLine(numbers.Sum());
            Console.WriteLine("Extracting numerics from a string and adding them is done.");
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
            //conversion.ValidateString();
            //conversion.IntOutOfString();
            //conversion.LongConversion();
            conversion.HexToInt();
            //conversion.ScienceToDouble(); 
            //conversion.HandlingNumbers(); 
            //conversion.TrimFunction(); 
            //conversion.DetectNumber(); 
            //conversion.FormatHandling();
            //conversion.FormatConversion();
            //conversion.TreatingNegative(); 
            //conversion.ConvertHoursIntoMinutes(); 
            //conversion.ExtractAndConvertNumeric(); 
            //conversion.IntSumFromString(); 
            //conversion.BinaryToInt(); 
            //conversion.ExtractAndSum();
        }
    }
}
